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

			// ?? FORZAR configuración ignorando launchSettings
			builder.WebHost.UseUrls("http://0.0.0.0:5117");

			// CORS para red local
			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowLocalNetwork",
					policy =>
					{
						policy.AllowAnyOrigin()
							  .AllowAnyHeader()
							  .AllowAnyMethod();
					});
			});

			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddDbContext<LDSContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("LDSContext")));

			#region Services
			builder.Services.AddScoped<IUnitMeasureService, UnitMeasureService>();
			builder.Services.AddScoped<IAreaService, AreaService>();
			builder.Services.AddScoped<IBrandService, BrandService>();
			builder.Services.AddScoped<ICategoryService, CategoryService>();
			builder.Services.AddScoped<IPriceHistoryService, PriceHistoryService>();
			builder.Services.AddScoped<IProductService, ProductService>();
			#endregion

			#region Repositories
			builder.Services.AddScoped<IUnitMeasureRepository, UnitMeasureRepository>();
			builder.Services.AddScoped<IAreaRepository, AreaRepository>();
			builder.Services.AddScoped<IBrandRepository, BrandRepository>();
			builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
			builder.Services.AddScoped<IProductRepository, ProductRepository>();
			builder.Services.AddScoped<IPriceHistoryRepository, PriceHistoryRepository>();
			#endregion

			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseCors("AllowLocalNetwork");
			app.UseAuthorization();
			app.MapControllers();

			app.Run();
		}
	}
}