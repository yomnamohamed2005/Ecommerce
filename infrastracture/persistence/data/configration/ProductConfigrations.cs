
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace persistence.data.configration
{
    internal class ProductConfigrations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(Product => Product.ProductBrand).WithMany()
                .HasForeignKey(Product => Product.BrandId);
            builder.HasOne(Product => Product.ProductType).WithMany()
                .HasForeignKey(Product => Product.TypeId);
            builder.Property(Product => Product.price).HasColumnType("decimal(18,3)");
              
        }
    }
}
