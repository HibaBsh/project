using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Data
{
    public class BookContext : IdentityDbContext<ApplicationUser>
    {
        IConfiguration Config;
        public BookContext(IConfiguration _Config)
        {
            Config = _Config;
        }
        public DbSet<Authors> authors { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Books> books { get; set; }
        public DbSet<Nationality> nationalities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.GetConnectionString("BookConnection"));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
