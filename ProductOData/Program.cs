using BusinessObject;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using ProductManagementAPI.Models;
using Repositories;

namespace ProductOData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped(typeof(ArtDbContext));
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

            //Dinh tuyen toi OData
            builder.Services.AddControllers().AddOData(o => o.Select().Filter().OrderBy().Expand()
            .Count().SetMaxTop(null).AddRouteComponents("odata", ModelBuilder.GetEDMModel()));

            // Add services to the container.

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseODataBatching();
            app.UseRouting();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
