using Microsoft.EntityFrameworkCore;
using ProjeAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ProjeAPI.Repository
{
    public class ProjeDbContext : DbContext
    {
        //Database Bağlantısı
        public ProjeDbContext(DbContextOptions<ProjeDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }

        //Migrate Edilecek Tablolar
        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
