
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using persistence.data;
using domain.contracts;
using persistence.repositories;

namespace Ecommerce
{
    public class Program
    {
        public static async Task Main( string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            builder.Services.AddControllers();
            builder.Services.AddDbContext<Storecontext>(options=>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddScoped<IDbinitializer,Dbinitializer>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            await initializerDBAsync(app);
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        async Task initializerDBAsync  (WebApplication app)
            {
                using var scope = app.Services.CreateScope();
                var dbinitializer = scope.ServiceProvider.GetRequiredService<IDbinitializer>();
                 await dbinitializer.initializeasnc();
            }
        }
    }
}
