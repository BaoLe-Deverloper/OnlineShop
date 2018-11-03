namespace OnlineShop.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataWeb : DbContext
    {
        public DataWeb()
            : base("name=DataWeb")
        {
        }

        public virtual DbSet<age> ages { get; set; }
        public virtual DbSet<GroupCategory> GroupCategories { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<productComment> productComments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TypeGroup> TypeGroups { get; set; }
        public virtual DbSet<UserAdmin> UserAdmins { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupCategory>()
                .HasMany(e => e.ProductCategories)
                .WithOptional(e => e.GroupCategory)
                .HasForeignKey(e => e.IDGroup);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.DetialProductName)
                .IsFixedLength();

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.DetialProductPrice)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .Property(e => e.OrderZip)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.OrderEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.OrderTrackingNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithOptional(e => e.Order)
                .HasForeignKey(e => e.DetialOrderID);

            modelBuilder.Entity<ProductCategory>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.ProductCategory)
                .HasForeignKey(e => e.ProductCategoryID);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetails)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.DetialProductID);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.productComments)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.CommentProductID);

            modelBuilder.Entity<Quyen>()
                .HasMany(e => e.UserAdmins)
                .WithOptional(e => e.Quyen)
                .HasForeignKey(e => e.UserIDQuyen);

            modelBuilder.Entity<UserAdmin>()
                .Property(e => e.UserEmail)
                .IsUnicode(false);

            modelBuilder.Entity<UserAdmin>()
                .Property(e => e.UserPhone)
                .IsUnicode(false);

            modelBuilder.Entity<UserAdmin>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.UserAdmin)
                .HasForeignKey(e => e.IDNhanVien);

            modelBuilder.Entity<UserAdmin>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.UserAdmin)
                .HasForeignKey(e => e.IDNhanvien);

            modelBuilder.Entity<User>()
                .Property(e => e.UserEmail)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserPass)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserVeificationCode)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Userphone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.OrderUserID);

            modelBuilder.Entity<User>()
                .HasMany(e => e.productComments)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.CommentUserID);
        }
    }
}
