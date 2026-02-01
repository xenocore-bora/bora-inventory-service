using Inventory.Application.Common.UnitOfWork;
using Inventory.Domain.Common.Aggregate;
using Inventory.Infrastructure.Outbox;

namespace Inventory.Infrastructure.Persistence.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly PgsqlDbContext _context;

    public UnitOfWork(PgsqlDbContext context)
    {
        _context = context;
    }

    private async Task DispatchEventsAsync(CancellationToken cancellationToken = default)
    {
        // Get aggregates from the change tracker. Only selects aggregates with changes.
        var aggregates = _context.ChangeTracker
            .Entries<AggregateRoot>()
            .Select(e => e.Entity)
            .ToList();
        
        Console.WriteLine(aggregates.Count);

        // Then dispatch events from those aggregates
        var events = aggregates.SelectMany(a => a.PullDomainEvents());

        // Add dispatched events to the outbox table
        await _context.OutboxMessages.AddRangeAsync(events.Select(OutboxMessage.Create).ToList(), cancellationToken);
    }

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        var tx = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            await DispatchEventsAsync(cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            await tx.CommitAsync(cancellationToken);
        }
        catch (Exception e)
        {
            await tx.DisposeAsync();
            await _context.Database.RollbackTransactionAsync(cancellationToken);
        }
    }
}