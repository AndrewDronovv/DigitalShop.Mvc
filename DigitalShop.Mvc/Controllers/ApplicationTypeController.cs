using DigitalShop.Mvc.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DigitalShop.Models;
using DigitalShop.Utility;

namespace DigitalShop.Mvc.Controllers;

[Authorize(Roles = WC.AdminRole)]
public class ApplicationTypeController : Controller
{
    private readonly AppDbContext _context;

    public ApplicationTypeController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        IEnumerable<ApplicationType> objList = _context.ApplicationTypes;
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
    public IActionResult Create(ApplicationType obj)
    {
        if (ModelState.IsValid)
        {
            _context.ApplicationTypes.Add(obj);
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
        var obj = _context.ApplicationTypes.Find(id);
        if (obj == null)
        {
            return NotFound();
        }
        return View(obj);
    }

    //POST - EDIT
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(ApplicationType obj)
    {
        if (ModelState.IsValid)
        {
            _context.ApplicationTypes.Update(obj);
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
        var obj = _context.ApplicationTypes.Find(id);
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
        var obj = _context.ApplicationTypes.Find(id);
        if (obj == null)
        {
            return NotFound();
        }
        _context.ApplicationTypes.Remove(obj);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
