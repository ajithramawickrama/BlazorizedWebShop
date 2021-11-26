using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using System.Runtime.InteropServices;

namespace MyFirstBlazorApp.Data;

public class DataInitializer
{
    public const string SqliteDbFilename = "test.db";
    private readonly Task firstTimeSetupTask;
    private readonly IDbContextFactory<ApplicationDbContext> dbContextFactory;
    private bool isSynchronizing;
    public DataInitializer(IJSRuntime js, IDbContextFactory<ApplicationDbContext> dbContextFactory)
    {
        this.dbContextFactory = dbContextFactory;
        firstTimeSetupTask = FirstTimeSetupAsync(js);
    }

    private async Task FirstTimeSetupAsync(IJSRuntime js)
    {
        var module = await js.InvokeAsync<IJSObjectReference>("import", "./dbstorage2.js");

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Create("browser")))
        {
            await module.InvokeVoidAsync("synchronizeFileWithIndexedDb", SqliteDbFilename);
        }

        using var db = await dbContextFactory.CreateDbContextAsync();
        await db.Database.EnsureCreatedAsync();
    }

    public async Task<ApplicationDbContext> GetPreparedDbContextAsync()
    {
        await firstTimeSetupTask;
        return await dbContextFactory.CreateDbContextAsync();
    }
}

