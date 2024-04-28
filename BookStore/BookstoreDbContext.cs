using Microsoft.EntityFrameworkCore;

namespace Bookstore.DAL
{
    public class BookstoreDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=BookstoreDB;Trusted_Connection=True;TrustServerCertificate=true;");


        }
    }
}
