

namespace BWS.Application;

public  class DBInitializer
{
    public const string SqliteDbFilename = "bws.db";
    private readonly IJSRuntime _jSRuntime;
    private readonly IDbContextFactory<BWSDbContext> _dbContextFactory;
    private readonly IOptions<Settings> _options;

    public DBInitializer(IJSRuntime jSRuntime, IDbContextFactory<BWSDbContext> dbContextFactory,IOptions<Settings> options)
    {
        _jSRuntime = jSRuntime;
        _dbContextFactory = dbContextFactory;
        _options = options;
    }

    public async Task FirstTimeSetupAsync()
    {
        var module = await _jSRuntime.InvokeAsync<IJSObjectReference>("import", "./indexedDbSettings.js");

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Create("browser")))
        {
            await module.InvokeVoidAsync("synchronizeFileWithIndexedDb", _options.Value.SqliteFileName, "BlazorWebShop");
        }

        using var db = await _dbContextFactory.CreateDbContextAsync();
        await db.Database.EnsureCreatedAsync();
    }

    public async Task<BWSDbContext> GetPreparedDbContextAsync()
    {
        return await _dbContextFactory.CreateDbContextAsync();
    }
}

