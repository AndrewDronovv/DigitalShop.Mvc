﻿using DigitalShop.Models;

namespace DigitalShop.Models.ViewModels;

public class ProductUserVM
{
    public ApplicationUser ApplicationUser { get; set; }
    public IList<Product> ProductList { get; set; }

    public ProductUserVM()
    {
        ProductList = new List<Product>();
    }
}
