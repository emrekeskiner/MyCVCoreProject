using Microsoft.EntityFrameworkCore;
using MyCvCore.Api.DAL.Entity;

namespace MyCvCore.Api.DAL.ApiContext
{
    public class ApiContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ultrabook;Initial Catalog=DbMyCv;Integrated Security=True");
        }

        public DbSet<Category> Categories { get; set; }
    }
}
