using Jīao.Data;
using Jīao.Repositories.Implementations;
using Jīao.Repositories.Interfaces;
using Jīao.Service.Implementations;
using Jīao.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Jīao
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<JīaoContext>(dbContextOptions => dbContextOptions.UseSqlite(
            builder.Configuration["ConnectionStrings:JīaoAPIDBConnectionString"]));

            #region DependencyInjections
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

            builder.Services.AddScoped<ISellerService, SellerService>();
            builder.Services.AddScoped<ISellerRepository, SellerRepository>();

            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

            builder.Services.AddScoped<IMarketStallService, MarketStallService>();
            builder.Services.AddScoped<IMarketStallRepository, MarketStallRepository>();
            #endregion


            var app = builder.Build();

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
        }
    }
}
