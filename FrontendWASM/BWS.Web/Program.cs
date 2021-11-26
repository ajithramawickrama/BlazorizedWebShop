

using Microsoft.JSInterop;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var backendUrl = builder.Configuration.GetSection("Settings")["APIBaseUrl"];
var sqliteFileName = builder.Configuration.GetSection("Settings")["SqliteFileName"];

var confi = builder.Configuration.GetSection("Settings");
builder.Services.Configure<Settings>(opt =>
{
    opt.APIBaseUrl = backendUrl;
    opt.SqliteFileName = sqliteFileName;
});

builder.Services.AddDbContextFactory<BWSDbContext>(
            options => options.UseSqlite($"Filename={sqliteFileName}"));

builder.Services.AddScoped<DBInitializer>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<IProductDataRepository, ProductDataRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerDataRepository, CustomerDataRepository>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<ISaleDataRepository, SaleDataRepository>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(backendUrl) });

var app = builder.Build();

var dbInitializer = app.Services.GetService<DBInitializer>();
await dbInitializer.FirstTimeSetupAsync();

await app.RunAsync();

