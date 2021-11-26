using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using MyFirstBlazorApp;
using MyFirstBlazorApp.Data;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

var backendUrl = builder.Configuration.GetSection("Settings")["APIBaseUrl"];

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddDbContextFactory<ApplicationDbContext>(
            options => options.UseSqlite($"Filename={DataInitializer.SqliteDbFilename}"));

builder.Services.AddScoped<DataInitializer>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(backendUrl) });

await builder.Build().RunAsync();
