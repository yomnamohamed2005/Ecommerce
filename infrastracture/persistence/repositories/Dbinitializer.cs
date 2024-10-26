using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.contracts;
using persistence.data;
using System.Text.Json;
namespace persistence.repositories
{
    

  public class Dbinitializer : IDbinitializer
    {
        private readonly Storecontext _storecontext;

        public Dbinitializer(Storecontext storecontext)
        {
            _storecontext = storecontext;
        }

        public  async Task initializeasnc()
        {
            try
            {
                if (_storecontext.Database.GetPendingMigrations().Any())
                    await _storecontext.Database.MigrateAsync();
                if (!_storecontext.ProductTypes.Any())
                {
                    var typedata = await File.ReadAllTextAsync(@"..\infrastracture\persistence\data\seeding\types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typedata);
                    if(types  is not null && types.Any())
                    {
                        await _storecontext.ProductTypes.AddRangeAsync(types);
                        await _storecontext.SaveChangesAsync();
                    }
                }
                if (!_storecontext.ProductBrands.Any())
                {
                    var branddata = await File.ReadAllTextAsync(@"..\infrastracture\persistence\data\seeding\brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(branddata);
                    if(brands != null && brands.Any())
                    {
                        await _storecontext.ProductBrands.AddRangeAsync(brands);
                        await _storecontext.SaveChangesAsync();
                    }
                }
                if (!_storecontext.Products.Any())
                {
                    var productdata = await File.ReadAllTextAsync(@"..\infrastracture\persistence\data\seeding\products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productdata);
                    if (products != null && products.Any())
                    {
                        await _storecontext.Products.AddRangeAsync(products);
                        await _storecontext.SaveChangesAsync();
                    }
                }
            }
            catch(Exception )
            {
                throw;
            }

        }
    }
}
