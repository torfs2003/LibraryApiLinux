using System;
using System.Collections.Generic;
using System.Linq;
using LibraryApiLinux.Models;

namespace LibraryApiLinux.Services
{
    class MockWebApiRepo : IWebApiRepo
    {
        private List<Book> bookList;

        public MockWebApiRepo()
        {
            bookList = new List<Book>
            {
                new Book
                {
                    Id = 0,
                    Title = "C# in Depth",
                    Author = "Jon Skeet",
                    Genre = "Programming",
                    Image = "csharp-in-depth.jpg",
                    Stock = 5,
                    IsAvailable = true,
                    IsInCart = false,
                    DueDate = null
                },
                new Book
                {
                    Id = 1,
                    Title = "Clean Code",
                    Author = "Robert C. Martin",
                    Genre = "Programming",
                    Image = "clean-code.jpg",
                    Stock = 3,
                    IsAvailable = true,
                    IsInCart = false,
                    DueDate = null
                },
                new Book
                {
                    Id = 2,
                    Title = "The Pragmatic Programmer",
                    Author = "Andy Hunt and Dave Thomas",
                    Genre = "Programming",
                    Image = "pragmatic-programmer.jpg",
                    Stock = 2,
                    IsAvailable = false,
                    IsInCart = true,
                    DueDate = DateTime.Now.AddDays(7)
                }
            };
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return bookList;
        }

        public Book GetBookById(int id)
        {
            return bookList.FirstOrDefault(b => b.Id == id);
        }

        public void AddBook(Book b)
        {
            b.Id = bookList.Max(b => b.Id) + 1;
            bookList.Add(b);
        }

        public void UpdateBook(Book book)
        {
            var existingBook = bookList.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.Genre = book.Genre;
                existingBook.Image = book.Image;
                existingBook.Stock = book.Stock;
                existingBook.IsAvailable = book.IsAvailable;
                existingBook.IsInCart = book.IsInCart;
                existingBook.DueDate = book.DueDate;
            }
        }

        public void DeleteBook(Book book)
        {
            var existingBook = bookList.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                bookList.Remove(existingBook);
            }
        }

        public int SaveChanges()
        {
            return 1;
        }
    }
}
