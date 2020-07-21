using Microsoft.EntityFrameworkCore;
using BooksListMvc2.Models;

namespace BooksListMvc2.Data {
    public class AppDbContext : DbContext {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {

        }

        public DbSet<Book> Book { get; set; }
        public DbSet<Category> Category { get; set; }


    }
}
