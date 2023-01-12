using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
                // Setup Authentication
                builder.Services.AddAuthentication(options =>
                {
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.Authority = builder.Configuration.GetSection("Auth0").GetValue<string>("Domain");
                    options.Audience = builder.Configuration.GetSection("Auth0").GetValue<string>("Audience");
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        RoleClaimType = "http://schemas.MKFY.com/roles"
                    };
                });

                // Setup Dependency Injection
                builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
                builder.Services.AddScoped<IMKFYListServise, MKFYListServise>();
                builder.Services.AddScoped<IUserService, UserService>();

            }


            // Setup our HTTP request / response pipeline
           void ConfigurePipeline(WebApplication app)
            {
                // Allow hosting of static web pages
                if (!app.Environment.IsProduction())
                {
                    app.UseDefaultFiles();
                    app.UseStaticFiles();
                }
                //app.UseHttpsRedirection();
                app.UseAuthentication();
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