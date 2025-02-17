using DigitalShop.Mvc.Data;
using DigitalShop.Models;
using DigitalShop.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using DigitalShop.Models.ViewModels;

namespace DigitalShop.Mvc.Controllers;

[Authorize]
public class CartController : Controller
{
    private readonly AppDbContext _context;
    [BindProperty]
    public ProductUserVM ProductUserVM { get; set; }

    public CartController(AppDbContext context)
    {
        _context = context;
    }


    public IActionResult Index()
    {
        List<ShoppingCart> shoppingCartList = new List<ShoppingCart>();
        if (HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart) != null
            && HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart).Count() > 0)
        {
            shoppingCartList = HttpContext.Session.Get<List<ShoppingCart>>(WC.SessionCart);
        }

        List<int> prodInCart = shoppingCartList.Select(i => i.ProductId).ToList();
        IEnumerable<Product> productList = _context.Products.Where(u => prodInCart.Contains(u.Id));

        return View(productList);
    }

    public IActionResult Remove(int id)
    {
        List<ShoppingCart> shoppingCartList = new List<ShoppingCart>();
        if (HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart) != null
            && HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart).Count() > 0)
        {
            shoppingCartList = HttpContext.Session.Get<List<ShoppingCart>>(WC.SessionCart);
        }

        shoppingCartList.Remove(shoppingCartList.FirstOrDefault(i => i.ProductId == id)!);
        HttpContext.Session.Set(WC.SessionCart, shoppingCartList);

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [ActionName(nameof(Index))]
    public IActionResult IndexPost()
    {
        return RedirectToAction(nameof(Summary));
    }

    public IActionResult Summary()
    {
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

        List<ShoppingCart> shoppingCartList = new List<ShoppingCart>();
        if (HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart) != null
            && HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart).Count() > 0)
        {
            shoppingCartList = HttpContext.Session.Get<List<ShoppingCart>>(WC.SessionCart);
        }

        List<int> prodInCart = shoppingCartList.Select(i => i.ProductId).ToList();
        IEnumerable<Product> productList = _context.Products.Where(u => prodInCart.Contains(u.Id));

        ProductUserVM = new ProductUserVM()
        {
            ApplicationUser = _context.ApplicationUsers.FirstOrDefault(u => u.Id == claim.Value),
            ProductList = productList.ToList(),
        };

        return View(ProductUserVM);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [ActionName("Summary")]
    public IActionResult SummaryPost(ProductUserVM productUserVM)
    {


        return RedirectToAction(nameof(InquiryConfirmation));
    }

    public IActionResult InquiryConfirmation(ProductUserVM productUserVM)
    {
        HttpContext.Session.Clear();
        return View(ProductUserVM);
    }
}
