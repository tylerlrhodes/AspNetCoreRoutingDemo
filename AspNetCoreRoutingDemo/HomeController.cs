using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreRoutingDemo.Models;
using AspNetCoreRoutingDemo.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreRoutingDemo
{
  public class HomeController : Controller
  {
    IBookStore _bookStore;

    public HomeController(IBookStore bookStore)
    {
      if (bookStore == null)
      {
        throw new ArgumentNullException();
      }

      _bookStore = bookStore;
    }

    // GET: /<controller>/
    public IActionResult Index()
    {
      return View(_bookStore);
    }

    [HttpGet]
    public IActionResult GetBookByNumber(int number)
    {
      Book book = _bookStore.GetBook(number);

      if (book != null) return View("GetBook", book);
      else return NotFound();
    }

    [HttpGet]
    public IActionResult GetBookBySlug(string slug)
    {
      Book book = _bookStore.GetBook(slug);

      if (book != null) return View("GetBook", book);
      else return NotFound();
    }

    [HttpGet]
    public IActionResult AddBook() => View();

    [HttpPost]
    public IActionResult AddBook(Book book)
    {
      if (ModelState.IsValid)
      {
        _bookStore.AddBook(book);
        return RedirectToAction(nameof(Index));
      }
      return View(book);
    }
  }
}
