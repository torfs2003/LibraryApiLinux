using System;
using System.Collections.Generic;
using System.Linq;
using LibraryApiLinux.Models;


namespace LibraryApiLinux.Services
{
    class MySqlWebApiRepo : IWebApiRepo
    {
        private readonly WebApiContext _context;
        public MySqlWebApiRepo(WebApiContext context)
        //constructor passing webapicontext via dependency injection
        {
            _context = context;
        }
        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }
        public Book GetBookById(int id)
        {
            return _context.Books.FirstOrDefault(p => p.Id == id);

        }
        public void AddBook(Book b)
        {
            _context.Books.Add(b); 
        }

        public void UpdateBook(Book b)
        {
            //Nothing needs to be implemented here
        }
        public void DeleteBook(Book b)
        {
            _context.Books.Remove(b);
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
