using DoAnSever.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoAnSever.DbContexts
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        
        
        public DbSet<Category> Categories { get; set; }

        public DbSet<Cart>Carts { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            


            modelBuilder.Entity<OrderDetail>()
                .HasKey( od => new {od.IdOrder, od.IdProduct});

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.IdOrder)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.IdProduct)
                .OnDelete(DeleteBehavior.Restrict);

           

            modelBuilder.Entity<Cart>()
                .HasKey(c => new { c.IdUser, c.IdProduct });
            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithMany(u => u.Carts)
                .HasForeignKey(c => c.IdUser)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Product)
                .WithMany(p => p.Carts)
                .HasForeignKey(od => od.IdProduct)
                .OnDelete(DeleteBehavior.Restrict);

           
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.IdUser)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Payment)
                .WithMany(p => p.Orders)   
                .HasForeignKey(o => o.IdPayment)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserRole>()
                .HasKey(r => new {r.IdRole, r.IdUser});
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.IdUser)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserRole>()
               .HasOne(ur => ur.Role)
               .WithMany(r => r.UserRoles)
               .HasForeignKey(ur => ur.IdRole)
               .OnDelete(DeleteBehavior.Restrict);
        }
    

    }
}
