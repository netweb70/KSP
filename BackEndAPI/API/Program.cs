using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API
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

         //  Ignore Cycles in response json object
         builder.Services.AddControllers().AddJsonOptions(option =>
         {
            option.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
         });

         // cors
         builder.Services.AddCors(options => options.AddPolicy("AllowWebapp",
            builder => builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()));

         // Add EF context
         builder.Services.AddDbContext<DB_Context>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"))
         );

         var app = builder.Build();

         // Configure the HTTP request pipeline.
         if (app.Environment.IsDevelopment())
         {
            app.UseSwagger();
            app.UseSwaggerUI();
         }

         app.UseHttpsRedirection();
         app.UseAuthorization();
         app.UseCors("AllowWebapp");

         app.MapControllers();

         app.Run();
      }
   }
}
