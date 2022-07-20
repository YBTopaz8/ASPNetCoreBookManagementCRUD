using BooksWeb.Models;

using Microsoft.EntityFrameworkCore;

namespace BooksWeb.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

       
    }
}
