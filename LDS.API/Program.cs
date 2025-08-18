
using LDS.Domain.Services.Interfaces;
using LDS.Domain.Services;
using LDS.Domain.Repositories;
using LDS.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using LDS.Infrastructure.Context;

namespace LDS.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

			// Agregar configuración CORS
			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowAngularDev",
					policy =>
					{
						policy.AllowAnyOrigin()
							  .AllowAnyHeader()
							  .AllowAnyMethod();
					});
			});

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

			builder.Services.AddDbContext<LDSContext>(options =>
	        options.UseSqlServer(builder.Configuration.GetConnectionString("LDSContext")));

			#region Services
			// Add services to the container.
            builder.Services.AddScoped<IUnitMeasureService, UnitMeasureService>();
			builder.Services.AddScoped<IAreaService, AreaService>();
			builder.Services.AddScoped<IBrandService, BrandService>();
			builder.Services.AddScoped<ICategoryService, CategoryService>();
			builder.Services.AddScoped<IPriceHistoryService, PriceHistoryService>();
			builder.Services.AddScoped<IProductService, ProductService>();
			#endregion

			#region Repositories
			// Add repositories to the container.
			builder.Services.AddScoped<IUnitMeasureRepository, UnitMeasureRepository>();
			builder.Services.AddScoped<IAreaRepository, AreaRepository>();
			builder.Services.AddScoped<IBrandRepository, BrandRepository>();
			builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
			builder.Services.AddScoped<IProductRepository, ProductRepository>();
			builder.Services.AddScoped<IPriceHistoryRepository, PriceHistoryRepository>();
			#endregion

			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

			app.UseCors("AllowAngularDev");

			//app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
        