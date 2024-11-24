using DigitalShop.Models;
using DigitalShop.Mvc.Data;
using DigitalShop.Mvc.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DigitalShop.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;

    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        HomeVM homeVM = new HomeVM
        {
            Products = _context.Products.Include(u => u.Category).Include(u => u.ApplicationType),
            Categories = _context.Categories
        };

        return View(homeVM);
    }

    public IActionResult Details(int id)
    {
        DetailsVM detailsVM = new DetailsVM()
        {
            Product = _context.Products.Include(u => u.Category).Include(u => u.ApplicationType).FirstOrDefault(u => u.Id == id),
            ExistsInCart = false
        };

        return View(detailsVM);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
