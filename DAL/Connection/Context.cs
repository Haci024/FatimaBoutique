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
   
    public class Context : IdentityDbContext<AppUser, IdentityRole, string>
        {
     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
            optionsBuilder.UseSqlServer("server=Odissey;initial catalog=FatimahBoutique;Integrated Security=true;TrustServerCertificate=True");
           
        }


        public DbSet<ContactUs> ContactUs { get; set; }

        public DbSet<FrequentlyQuestions> FrequentlyQuestions { get; set; }

        public DbSet<Categories> Categories { get; set; }

        public DbSet<Slider> Slider { get; set; }

        public DbSet<Videos> Videos { get; set; }

        public DbSet<Blogs> Blogs { get; set; }

        public DbSet<BlogImages> BlogsImages { get; set; }

        public DbSet<AboutUs> AboutUs { get; set; }

        public DbSet<SocialMedia> SocialMedia { get; set; }

       



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogImages>()
                .HasOne(x => x.Blog).
                WithMany(x => x.BlogImages).
                HasForeignKey(x => x.BLogsId).
                OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Blogs>()
               .HasOne(x => x.Categories).
               WithMany(y => y.Blogs).
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
