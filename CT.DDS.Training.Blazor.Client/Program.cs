using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using BethanysPieShopHRM.Shared;
using CT.DDS.Training.Blazor.Services;
using System.Net.Http;

namespace CT.DDS.Training.Blazor.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddSingleton<DataFactory>();
            builder.Services.AddScoped<HttpClient>((s) => {
                var client = new HttpClient() { BaseAddress = new Uri("https://localhost:44340/") };
                return client;
                
            });
            builder.Services.AddScoped<IEmployeeDataService, EmployeeDataService>();
            builder.Services.AddScoped<ICountryDataService, CountryDataService>();
            builder.Services.AddScoped<IJobCategoryDataService, JobCategoryDataService>();
            builder.RootComponents.Add<App>("app");

            await builder.Build().RunAsync();
        }
    }
}
