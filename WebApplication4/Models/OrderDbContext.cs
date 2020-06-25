using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Customer> customers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Confectionery> confectioneries { get; set; }

        public DbSet<Confectionery_Order> confectionery_Orders { get; set; }

        public DbSet<Order> orders { get; set; }

        public OrderDbContext() { }

        public OrderDbContext(DbContextOptions options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Confectionery>(opt =>
            {
                opt.HasKey(e => e.idConfectionery);
                opt.Property(e => e.idConfectionery).ValueGeneratedOnAdd();
                opt.Property(e => e.Name).HasMaxLength(200).IsRequired();
                opt.Property(e => e.Type).HasMaxLength(40).IsRequired();
            });

            modelBuilder.Entity<Confectionery_Order>(opt =>
            {
                opt.HasKey(e => new { e.idOrder, e.idConfectionery });
                opt.HasOne(e => e.order).WithMany(e => e.Confectionery_Orders).HasForeignKey(e => e.idOrder);
                opt.HasOne(e => e.confectionery).WithMany(e => e.Confectionery_Orders).HasForeignKey(e => e.idConfectionery);
                opt.Property(e => e.Notes).HasMaxLength(255);
            });

            modelBuilder.Entity<Order>(opt =>
            {
                opt.HasKey(e => e.idOrder);
                opt.Property(e => e.idOrder).ValueGeneratedOnAdd();
                opt.HasOne(e => e.customer).WithMany(e => e.Orders).HasForeignKey(e => e.idClient);
                opt.HasOne(e => e.employee).WithMany(e => e.Orders).HasForeignKey(e => e.idEmployee);
                opt.Property(e => e.Notes).HasMaxLength(255);
            });

            modelBuilder.Entity<Customer>(opt =>
            {
                opt.HasKey(e => e.idClient);
                opt.Property(e => e.idClient).ValueGeneratedOnAdd();
                opt.Property(e => e.Name).HasMaxLength(50);
                opt.Property(e => e.Surname).HasMaxLength(60);
            });

            modelBuilder.Entity<Employee>(opt =>
            {
                opt.HasKey(e => e.idEmployee);
                opt.Property(e => e.idEmployee).ValueGeneratedOnAdd();
                opt.Property(e => e.Name).HasMaxLength(50);
                opt.Property(e => e.Surname).HasMaxLength(60);
            });
        }
    }
}
    
