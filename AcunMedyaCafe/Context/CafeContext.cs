using AcunMedyaCafe.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcunMedyaCafe.Context
{
    public class CafeContext : DbContext
    {
        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=GAMZE\\SQLEXPRESS;initial catalog=DbAcunMedyaCafe;integrated Security=true; TrustServerCertificate=True");
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Subscribe> Subscribers { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }


    }
}