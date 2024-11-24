using DigitalShop.Mvc.Data;
using DigitalShop.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace DigitalShop.Mvc.Controllers;

public class CategoryController : Controller
{
    private readonly AppDbContext _context;

    public CategoryController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        IEnumerable<Category> objList = _context.Categories;
        return View(objList);
    }

    //GET - CREATE
    public IActionResult Create()
    {
        return View();
    }

    //POST - CREATE
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category obj)
    {
        if (ModelState.IsValid)
        {
            _context.Categories.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    //GET - EDIT
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var obj = _context.Categories.Find(id);
        if (obj == null)
        {
            return NotFound();
        }
        return View(obj);
    }

    //POST - EDIT
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category obj)
    {
        if (ModelState.IsValid)
        {
            _context.Categories.Update(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    //GET - DELETE
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var obj = _context.Categories.Find(id);
        if (obj == null)
        {
            return NotFound();
        }
        return View(obj);
    }

    //POST - DELETE
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(int? id)
    {
        var obj = _context.Categories.Find(id);
        if (obj == null)
        {
            return NotFound();
        }
        _context.Categories.Remove(obj);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}