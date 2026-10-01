using Microsoft.EntityFrameworkCore;
using MovieReservationAPI.Data;
using MovieReservationAPI.Repositories.impelmentations;
using MovieReservationAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using MovieReservationAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MovieReservationAPI.Services.Interfaces;
using MovieReservationAPI.Repositories.Implementations;

public partial class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

        // Learn more about configuring OpenAPI & Swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddOpenApi();

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Repositories
        builder.Services.AddScoped<IMovieRepository, MovieRepository>();
        builder.Services.AddScoped<ICinemaRepositories, CinemaRepositories>();
        builder.Services.AddScoped<IScreenRepositories, ScreenRepositories>();
        builder.Services.AddScoped<ISeatRepositories, SeatRepositories>();
        builder.Services.AddScoped<IShowTimeRepositories, ShowTimeRepositories>();
        builder.Services.AddScoped<IBookingRepositories, BookingRepositories>();
        builder.Services.AddScoped<IUserRepositories, UserRepositories>();

        // Services
        builder.Services.AddScoped<ICinemaService, MovieReservationAPI.Services.Implementations.CinemaService>();
        builder.Services.AddScoped<IScreenService, MovieReservationAPI.Services.Implementations.ScreenService>();
        builder.Services.AddScoped<ISeatService, MovieReservationAPI.Services.Implementations.SeatService>();
        builder.Services.AddScoped<IShowTimeService, MovieReservationAPI.Services.Implementations.ShowTimeService>();
        builder.Services.AddScoped<IBookingService, MovieReservationAPI.Services.Implementations.BookingService>();
        builder.Services.AddScoped<IUserService, MovieReservationAPI.Services.Implementations.UserService>();

        // Identity
        builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = true;
            options.Password.RequireLowercase = true;
        })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        // JWT Authentication
        var jwtSettings = builder.Configuration.GetSection("JwtSettings");
        var secret = jwtSettings.GetValue<string>("Secret");
        var key = Encoding.ASCII.GetBytes(secret);

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = "JwtBearer";
            options.DefaultChallengeScheme = "JwtBearer";
        })
            .AddJwtBearer("JwtBearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.GetValue<string>("Issuer"),
                    ValidAudience = jwtSettings.GetValue<string>("Audience"),
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieReservationAPI v1");
                c.RoutePrefix = string.Empty; // بتخلي الـ Swagger يفتح مباشرة أول ما تفتحي الـ Root URL من غير ما تكتبي /swagger يدوياً
            });
        }

        app.UseHttpsRedirection();

        // Authentication & Authorization
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        // Seed roles and default admin
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            try
            {
                var db = services.GetRequiredService<ApplicationDbContext>();
                await db.Database.MigrateAsync();
            }
            catch (Exception)
            {
                throw;
            }

            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            var roles = new[] { "Admin", "Customer" };
            foreach (var role in roles)
            {
                var exists = await roleManager.RoleExistsAsync(role);
                if (!exists)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var adminEmail = builder.Configuration.GetValue<string>("DefaultAdmin:Email");
            var adminPassword = builder.Configuration.GetValue<string>("DefaultAdmin:Password");

            if (!string.IsNullOrEmpty(adminEmail))
            {
                var adminUser = await userManager.FindByEmailAsync(adminEmail);
                if (adminUser == null)
                {
                    adminUser = new ApplicationUser { UserName = adminEmail, Email = adminEmail, Name = "Administrator" };
                    var result = await userManager.CreateAsync(adminUser, adminPassword);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(adminUser, "Admin");
                    }
                }
            }
        }

        app.Run();
    }
}