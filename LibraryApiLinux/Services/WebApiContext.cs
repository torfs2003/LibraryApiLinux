using Microsoft.EntityFrameworkCore;
using LibraryApiLinux.Models;

namespace LibraryApiLinux.Services
{
    public class WebApiContext : DbContext
    {
        //DbContext base class is part of EntityFramework
        public WebApiContext(DbContextOptions<WebApiContext> opt) : base(opt) { }
        //Constructor will map this class to dbcontext
        public DbSet<Book> Books { get; set; }
        //Mapping model class to database table "Persons"
    }
}
