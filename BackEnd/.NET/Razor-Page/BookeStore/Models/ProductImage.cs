using System;
using System.Collections.Generic;

namespace BookStore.Models;

public partial class ProductImage
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string? ProductImage1 { get; set; }

    public virtual Product Product { get; set; } = null!;
}
