
using LDS.Domain.Services.Interfaces;
using LDS.Domain.Services;
using LDS.Domain.Repositories;
using LDS.Infrastructure.Repositories;

namespace LDS.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

			// Add services to the container.
			builder.Services.AddScoped<IAreaService, AreaService>();
			builder.Services.AddScoped<IBrandService, BrandService>();
			builder.Services.AddScoped<ICategoryService, CategoryService>();
			builder.Services.AddScoped<IPriceHistoryService, PriceHistoryService>();
			builder.Services.AddScoped<IProductService, ProductService>();

			// Add repositories to the container.
			builder.Services.AddScoped<IAreaRepository, AreaRepository>();
			builder.Services.AddScoped<IBrandRepository, BrandRepository>();
			builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
			builder.Services.AddScoped<IProductRepository, ProductRepository>();
			builder.Services.AddScoped<IPriceHistoryRepository, PriceHistoryRepository>();

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
