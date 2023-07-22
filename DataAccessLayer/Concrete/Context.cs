using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:IdentityDbContext<AppUser,AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=94.73.170.33;Initial Catalog=u1323082_dbYkr; User Id=u1323082_user1FA;Password=N.c:5yu2vB2N7Z@_");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryLanguageItem> CategoryLanguageItems { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductLanguageItem> ProductLanguageItems { get; set; }
        public DbSet<SubProduct> SubProducts { get; set; }
        public DbSet<SubProductLanguageItem> SubProductLanguageItems { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<AboutLanguageItem> AboutLanguageItems { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactLanguageItem> ContactLanguageItems { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeLanguageItem> EmployeeLanguageItems { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Home> Homes { get; set; }
        public DbSet<HomeLanguageItem> HomeLanguageItems { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<FooterLanguageItem> FooterLanguageItems { get; set; }
    }
}
