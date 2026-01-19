using Inventory.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Inventory.Infrastructure.Outbox;

public class OutboxWorker : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public OutboxWorker(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    private async Task ProcessOutboxMessagesAsync(CancellationToken cancellationToken)
    {
        using var scope = _scopeFactory.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<PgsqlDbContext>();

        var messages = db.OutboxMessages
            .Where((om) => !om.Processed)
            .OrderBy(om => om.OccurredOn)
            .Take(20).AsTracking();

        foreach (var message in messages)
        {
            try
            {
                // Something will go here, but later.
                message.MarkAsProcessed();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong processing message {message.Id}: {e.Message}");
                throw;
            }
        }
        await db.SaveChangesAsync(cancellationToken);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await ProcessOutboxMessagesAsync(stoppingToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}