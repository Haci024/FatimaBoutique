using Entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DbConnection
{
   
    public class Context : IdentityDbContext<AppUser>
        {
     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {

            //optionsBuilder.UseSqlServer("server=77.245.159.27\\MSSQLSERVER2019;initial catalog=FatimahBoutique;user=FatimahAdmin;password=6!3dRpp48;TrustServerCertificate=True");
            optionsBuilder.UseSqlServer("server=Odissey;database=FatimaBoutique;integrated security=true;TrustServerCertificate=True;MultipleActiveResultSets=True;");//Database ilə əlaqə
            optionsBuilder.EnableSensitiveDataLogging();


        }
        //server hissesine 77.45.159.27 bu ip yaz mssql de.Istifadeci ve password da yuxaridaki baglantida var.Ordan goture bilersen.

        public DbSet<ContactUs> ContactUs { get; set; }

        public DbSet<FrequentlyQuestions> FrequentlyQuestions { get; set; }

        public DbSet<Categories> Categories { get; set; }

        public DbSet<Slider> Slider { get; set; }
      
        public DbSet<Videos> Videos { get; set; }

        public DbSet<Products> Products { get; set; }

        public DbSet<ProductsImages> ProductImages { get; set; }

        

        //public DbSet<Basket> Basket { get; set; }

        //public DbSet<Orders> Orders { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Subscribers> Subscribers { get; set; }    



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductsImages>()
                .HasOne(x => x.Products).
                WithMany(x => x.ProductsImages).
                HasForeignKey(x => x.ProductId).
                OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Products>()
               .HasOne(x => x.Categories).
               WithMany(y => y.Products).
               HasForeignKey(x => x.CategoryId).
               OnDelete(DeleteBehavior.ClientSetNull);


            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
           new IdentityRole { Id = "fqIdllcwpqQdmlzdjlmp", Name = "SuperAdmin", NormalizedName = "SUPERADMIN" },
           new IdentityRole { Id = "LWwjdefnsldfsdlfndjs", Name = "Admin", NormalizedName = "ADMIN" },
           new IdentityRole { Id = "qOLKNNDsskdfkjsdksdkjc", Name = "User", NormalizedName = "USER" }
         
       );
          
        }
    }
    
}
