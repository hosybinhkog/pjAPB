using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace pjWebBPA.contextModels
{
    public partial class contextDBapb : DbContext
    {
        public contextDBapb()
            : base("name=contextDBapb3")
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<CategoryBlog> CategoryBlogs { get; set; }
        public virtual DbSet<CategoryCourse> CategoryCourses { get; set; }
        public virtual DbSet<CustomerUser> CustomerUsers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<ProductCourse> ProductCourses { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<StaticPage> StaticPages { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }

        public virtual DbSet<description> Descriptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryCourse>()
                .HasMany(e => e.ProductCourses)
                .WithRequired(e => e.CategoryCourse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerUser>()
                .HasMany(e => e.Blogs)
                .WithRequired(e => e.CustomerUser)
                .HasForeignKey(e => e.AccountId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerUser>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.CustomerUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserAccount>()
                .HasMany(e => e.CategoryBlogs)
                .WithOptional(e => e.UserAccount)
                .HasForeignKey(e => e.UserAccountId);
        }
    }
}
