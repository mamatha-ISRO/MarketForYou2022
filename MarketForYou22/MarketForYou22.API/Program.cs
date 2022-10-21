using Microsoft.EntityFrameworkCore;
using MKFY.Repositories;
using MKFY.Services.Services;
using MKFY.Services.Services.Interfaces;

namespace MarketForYou22.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Setup low-level functionality like configuration providers, etc.
            void ConfigureHost(ConfigureHostBuilder host)
            {

            }
            // Setup services like database providers, etc.
            void ConfigureServices(WebApplicationBuilder builder)
            {
                builder.Services.AddControllers();
                // Setup the database using the ApplicationDbContext
                builder.Services.AddDbContext<MKFYApplicationDbContext>(options =>
                    options.UseNpgsql(  // Connect to the Postgres database
                        builder.Configuration.GetConnectionString("DefaultConnection"),
                        b =>
                        {
                // Configure what project we want to store our Code-First Migrations in
                            b.MigrationsAssembly("MKFY.Repositories");
                        })
                    );
                // Setup Dependency Injection
                builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
                builder.Services.AddScoped<IMKFYListServise, MKFYListServise>();


            }


            // Setup our HTTP request / response pipeline
           void ConfigurePipeline(WebApplication app)
            {
                //app.UseHttpsRedirection();
                app.UseAuthorization();
                app.MapControllers();
               
            }
            // Execute database migrations
            void ExecuteMigrations(WebApplication app)
            {
                using (var scope = app.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;

                    var context = services.GetRequiredService<MKFYApplicationDbContext>();
                    context.Database.Migrate();
                }
            }
            #region
            var builder = WebApplication.CreateBuilder(args);
            //Setup the application
            ConfigureHost(builder.Host);
            ConfigureServices(builder);
            var app = builder.Build();

            // Execute migrations on startup
            ExecuteMigrations(app);
            // Configure the HTTP  pipeline.
            ConfigurePipeline(app);
            // Run your code
            app.Run();
            #endregion




        }
    }
}