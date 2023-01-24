using BlazorOdata.Server;
using BlazorOdata.Shared;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace BlazorOdata
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddSingleton<WeatherForecastService>();

            builder.Services.AddControllersWithViews()
            //builder.Services.AddControllers()
                .AddOData(options => options.AddRouteComponents(routePrefix: "odata", GetEdmModel())
                    .Select()
                    .Filter()
                    .Expand()
                    .Count()
                    .OrderBy()
                    .SetMaxTop(maxTopValue: 200));

            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();


            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
        public static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();

            builder.EntitySet<WeatherForecast>(name: "WeatherForecasts")
                .EntityType.HasKey(weatherForecast => weatherForecast.Id);

            return builder.GetEdmModel();
        }

    }
}