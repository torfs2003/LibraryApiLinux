using System;
using LibraryApiLinux.Models;

namespace LibraryApiLinux.Services
{
    public interface IWebApiRepo
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        void AddBook(Book b);
        void UpdateBook(Book b);
        void DeleteBook(Book b);
        int SaveChanges();
    }
}
