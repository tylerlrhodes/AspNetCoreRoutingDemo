using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreRoutingDemo.Models;
using System.Net;
using System.Text.RegularExpressions;

namespace AspNetCoreRoutingDemo.Services
{
  public class BookStore : IBookStore
  {
    List<Book> bookList;

    public BookStore()
    {
      bookList = new List<Book>();
    }

    public void AddBook(Book book)
    {
      //book.Slug = Regex.Replace(book.Title, @"\s+", "");

      //book.Slug = Regex.Unescape(book.Title);

      book.Slug = WebUtility.HtmlEncode(book.Slug);
      
      bookList.Add(book);
    }

    public Book GetBook(int number)
    {
      return bookList.Where(b => b.Number == number).FirstOrDefault();
    }

    public Book GetBook(string slug)
    {
      return bookList.Where(b => b.Slug == slug).FirstOrDefault();
    }

    public IEnumerable<Book> GetBooks()
    {
      return bookList;
    }
  }
}
