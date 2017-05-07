using AspNetCoreRoutingDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreRoutingDemo.Services
{
  public interface IBookStore
  {
    void AddBook(Book book);
    Book GetBook(int number);
    Book GetBook(string slug);
    IEnumerable<Book> GetBooks(); 
  }
}
