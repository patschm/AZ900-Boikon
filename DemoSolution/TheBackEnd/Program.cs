using Microsoft.EntityFrameworkCore;
using Shop.Dal;

namespace TheBackEnd;

public class Program
{
    public static void Main(string[] args)
    {

        var constr = Environment.GetEnvironmentVariable("PC_CONSTR");
        
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddDbContext<ProductCatalogContext>(opts => {
            opts.UseSqlServer(constr);
        });
        builder.Services.AddControllers();
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

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}