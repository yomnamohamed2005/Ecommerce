

namespace persistence.data
{
 public class Storecontext :DbContext
    {
        public Storecontext(DbContextOptions<Storecontext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Storecontext).Assembly);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes{ get; set; }
    }
}
