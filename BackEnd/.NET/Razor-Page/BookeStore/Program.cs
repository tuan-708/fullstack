using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using BookStore.Models;
using System.Security.Principal;
using System;
using BookStore.Areas.Identity.Data;
using System.Configuration;
using BookStore.Pages.Hubs;

var builder = WebApplication.CreateBuilder(args);
var cofiguration = builder.Configuration;

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'BookStoreContextConnection' not found.");

builder.Services.AddDbContext<BookStoreContext>(options => options.UseSqlServer(connectionString));

// Đăng ký IntityFramwork, sử dụng kết nối đến MS SQL Server
builder.Services.AddIdentity<AppUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddEntityFrameworkStores<BookStoreContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();

// Đăng ký StoresManagementContext, sử dụng kết nối đến MS SQL Server
builder.Services.AddDbContext<StoresManagementContext>(options => {
    string connectstring = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectstring);
});


//Config cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    //Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(1000);

    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});

// Config authentication provider
builder.Services.AddAuthentication()
    .AddGoogle(ggOptions => {
        ggOptions.ClientId = cofiguration.GetSection("GoogleAuthSettings").GetValue<string>("ClientId");
        ggOptions.ClientSecret = cofiguration.GetSection("GoogleAuthSettings").GetValue<string>("ClientSecret");
        ggOptions.SaveTokens = true;
    })
    .AddFacebook(fbOptions => {
        fbOptions.AppId = cofiguration.GetSection("FacebookSettings").GetValue<string>("AppId");
        fbOptions.AppSecret = cofiguration.GetSection("FacebookSettings").GetValue<string>("AppSecret");
    })
    .AddGitHub(githubOptions => {
        githubOptions.ClientId = cofiguration.GetSection("GithubSettings").GetValue<string>("ClientId");
        githubOptions.ClientSecret = cofiguration.GetSection("GithubSettings").GetValue<string>("ClientSecret");
    });


builder.Services.AddSignalR();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = new[] { "Admin", "Managemer", "User", "Employee" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

    //for (int i = 0; i < 150; i++)
    //{
    //    var user = new AppUser();
    //    user.UserName = $"test{i}@gmail.com";
    //    user.Email = $"test{i}@gmail.com";
    //    user.FirstName = "account";
    //    user.LastName = $"test{i}";
    //    user.Dob = DateTime.Now;
    //    await userManager.CreateAsync(user, "Tuan1234.");
    //    await userManager.AddToRoleAsync(user, "User");
    //}


    string email = cofiguration.GetSection("Admintrator").GetValue<string>("UserName");
    string password = cofiguration.GetSection("Admintrator").GetValue<string>("Password");
    if (await userManager.FindByNameAsync(email) == null)
    {
        var user = new AppUser();
        user.UserName = email;
        user.Email = email;

        await userManager.CreateAsync(user, password);

        await userManager.AddToRoleAsync(user, "Admin");
    }
}

app.MapHub<OrderHub>("/ProductOrder");

app.Run();