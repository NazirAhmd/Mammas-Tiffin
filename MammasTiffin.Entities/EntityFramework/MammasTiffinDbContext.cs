namespace MammasTiffin.Entities.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MammasTiffinDbContext : DbContext
    {
        public MammasTiffinDbContext()
            : base("name=MammasTiffinDbContext")
        {
        }

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderedItem> OrderedItems { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .Property(e => e.ItemName)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.IsVeg)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Item>()
                .Property(e => e.Ingredients)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.RowVersionStamp)
                .IsFixedLength();

            modelBuilder.Entity<Item>()
                .HasMany(e => e.OrderedItems)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.IsActive)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.IsDelivered)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.RowVersionStamp)
                .IsFixedLength();

            modelBuilder.Entity<OrderDetail>()
                .HasMany(e => e.OrderedItems)
                .WithRequired(e => e.OrderDetail)
                .HasForeignKey(e => e.OrderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderedItem>()
                .Property(e => e.RowVersionStamp)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.EmailId)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.MobileNum)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.RowVersionStamp)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);
        }
    }
}
