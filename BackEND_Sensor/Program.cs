using NetCoreAPIMySQL.Data;
using NetCoreAPIMySQL.Data.Repertorio;
using System.Configuration;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        var mySQLConnectionConfig = new MySQLConfiguration(builder.Configuration.GetConnectionString("MySQLConnection"));
        builder.Services.AddSingleton(mySQLConnectionConfig);
        builder.Services.AddScoped<IsensorRepo, SensorRepo>();
        var app = builder.Build();
       

       


        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
{
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();

        }
        
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}