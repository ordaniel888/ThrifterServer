namespace Thrifter.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ThrifterModel : DbContext
    {
        public ThrifterModel()
            : base("name=ThrifterModel")
        {
        }

        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<ProductOwnership> ProductOwnerships { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>()
                .HasMany(e => e.ProductOwnerships)
                .WithRequired(e => e.Owner)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ImageLink)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductOwnerships)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);
        }
    }
}
