using Microsoft.AspNetCore.Mvc;
using Spending_Web.Models;
using System.Diagnostics;
using System.Security.AccessControl;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Linq;
using Spending_Web.Repository;
using Spending_Web.DataAccess;


namespace Spending_Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        public IAccountRepository accountRepository = new AccountRepository();
        public ITransactionRevenueRepository transactionRevenueRepository = new TransactionRevenueRepository();
        public ITransactionSpendRepository transactionSpendRepository = new TransactionSpendRepository();
        public ICategoryRevenueRepository categoryRevenue = new CategoryRevenueRepository();
        public ICategorySpendRepository categorySpend = new CategorySpendRepository();

        public Account Account { get; set; }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            ClaimsPrincipal claimUser = HttpContext.User;
            if (!claimUser.Identity.IsAuthenticated)
            {
                return RedirectToAction("login", "access");
            }

            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            Account account =   accountRepository.GetAccountByAccountName(currentUserID);
            Account = account;

            List<ReportIncome> ListRevenueMonthly = ReportIncomeDAO.Intance.GetListRevenueMonthly(account);

            List<ReportIncome> ListSpendMonthly = ReportIncomeDAO.Intance.GetListSpendMonthly(account);

            ViewData["ListRevenueMonthly"] = ListRevenueMonthly;
            ViewData["ListSpendMonthly"] = ListSpendMonthly;

            return View();
        }

        public IActionResult Transaction(string filter)
        {

            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            Account account = accountRepository.GetAccountByAccountName(currentUserID);
            Account = account;

            DateTime DTTo;
            DateTime DTFrom;

            DTTo = DateTime.Now;

            TimeSpan aInterval = new TimeSpan(30, 0, 0, 0);

            DTFrom = DTTo.Subtract(aInterval);

            if (filter == "30day")
            {
                DTTo = DateTime.Now;

                TimeSpan aInterval1 = new TimeSpan(30, 0, 0, 0);

                DTFrom = DTTo.Subtract(aInterval1);
            }
            else if (filter == "today")
            {
                DTTo = DateTime.Now;

                DTFrom = new DateTime(DTTo.Year, DTTo.Month, DTTo.Day - 1, 23, 59, 59);
            }
            else if (filter == "thisWeek")
            {
                DTTo = DateTime.Now;

                int startOfWeek = (int)DayOfWeek.Monday;
                int daysSinceStartOfWeek = ((int)DTTo.DayOfWeek + 7 - startOfWeek) % 7;

                DTFrom = DTTo.AddDays(-daysSinceStartOfWeek);
                DTFrom = new DateTime(DTFrom.Year, DTFrom.Month, DTFrom.Day - 1, 23, 59, 59);

            }
            else if (filter == "thisMonth")
            {
                DTTo = DateTime.Now;
                DTFrom = new DateTime(DTTo.Year, DTTo.Month, 1);
            }

            List<TransactionRevenue> listTransactionRevene =  transactionRevenueRepository.GetTransactionRevenues(Account, DTFrom, DTTo);

            List<TransactionSpend> listTransactionSpend =  transactionSpendRepository.GetTransactionSpends(Account, DTFrom, DTTo);

            List<CategoryRevenue> categoryRevenues =  categoryRevenue.getCategorys();

            List<CategorySpend> categorySpends =  categorySpend.getCategorys();

            ViewData["listTransactionRevene"] = listTransactionRevene;
            ViewData["listTransactionSpend"] = listTransactionSpend;
            ViewData["categoryRevenues"] = categoryRevenues;
            ViewData["categorySpends"] = categorySpends;
            ViewData["filter"] = filter;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveTransaction(SaveTransaction saveTransaction)
        {
            try
            {
                ClaimsPrincipal currentUser = this.User;
                var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

                Account account = accountRepository.GetAccountByAccountName(currentUserID);
                Account = account;

                if (saveTransaction.TypeCategory == "Category Revenue")
                {
                    TransactionRevenue transaction = new TransactionRevenue();

                    transaction.DateRevenue = saveTransaction.Date;
                    transaction.Amount = saveTransaction.Amount;
                    transaction.Description = saveTransaction.Description;
                    transaction.CategoryRevenue = saveTransaction.CategoryRevenue;
                    transaction.IdAccount = Account.Id;

                    transactionRevenueRepository.InsertTransactionRevenue(transaction);

                }
                else
                {
                    TransactionSpend transaction = new TransactionSpend();

                    transaction.DateSpend = saveTransaction.Date;
                    transaction.Amount = saveTransaction.Amount;
                    transaction.Description = saveTransaction.Description;
                    transaction.CategorySpend = saveTransaction.CategorySpend;
                    transaction.IdAccount = Account.Id;

                    transactionSpendRepository.InsertTransactionSpend(transaction);
                }

                return RedirectToAction("Transaction", "Home");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Transaction", "Home");
            }
        }


        [HttpPost]
        public async Task<IActionResult> TransactionsFilter(String radio)
        {
            return RedirectToAction("Transaction", "Home", new { filter = radio });
        }

            public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Access");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTransactionRevenue(TransactionRevenue transaction)
        {
            try
            {
                ClaimsPrincipal currentUser = this.User;
                var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

                Account account = accountRepository.GetAccountByAccountName(currentUserID);
                Account = account;

                transaction.IdAccount = Account.Id;

                transactionRevenueRepository.UpdateTransactionRevenue(transaction);
            }
            catch {
                return RedirectToAction("Transaction", "Home");
            }
            return RedirectToAction("Transaction", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> EditTransactionSpend(TransactionSpend transaction)
        {
            try
            {
                ClaimsPrincipal currentUser = this.User;
                var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

                Account account = accountRepository.GetAccountByAccountName(currentUserID);
                Account = account;

                transaction.IdAccount = Account.Id;

                transactionSpendRepository.UpdateTransactionSpend(transaction);
            }
            catch
            {
                return RedirectToAction("Transaction", "Home");
            }
            return RedirectToAction("Transaction", "Home");
        }


        public async Task<IActionResult> DeleteTransactionSpend(int id)
        {
            transactionSpendRepository.DeleteTransactionSpend(id);
            return RedirectToAction("Transaction", "Home");
        }

        public async Task<IActionResult> DeleteTransactionRevenue(int id)
        {
            transactionRevenueRepository.DeleteTransactionRevenue(id);
            return RedirectToAction("Transaction", "Home");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}