﻿#region Corpspace© Apache-2.0
// Copyright © 2023 Sultan Soltanov. All rights reserved.
// Author: Sultan Soltanov
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

using Corpspace.BuildingBlocks.EventBus.Events;

namespace Corpspace.BuildingBlocks.IntegrationEventLogEF.Services;

public class IntegrationEventLogService : IIntegrationEventLogService, IDisposable
{
    private readonly IntegrationEventLogContext _integrationEventLogContext;
    private readonly DbConnection _dbConnection;
    private readonly List<Type> _eventTypes;
    private volatile bool _disposedValue;

    public IntegrationEventLogService(DbConnection dbConnection)
    {
        _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
        _integrationEventLogContext = new IntegrationEventLogContext(
            new DbContextOptionsBuilder<IntegrationEventLogContext>()
                .UseNpgsql(_dbConnection)
                .Options);

        _eventTypes = Assembly.Load(Assembly.GetEntryAssembly().FullName)
            .GetTypes()
            .Where(t => t.Name.EndsWith(nameof(IntegrationEvent)))
            .ToList();
    }

    public async Task<IEnumerable<IntegrationEventLogEntry>> RetrieveEventLogsPendingToPublishAsync(Guid transactionId)
    {
        var tid = transactionId.ToString();

        var result = await _integrationEventLogContext.IntegrationEventLogs
            .Where(e => e.TransactionId == tid && e.State == EventStateEnum.NotPublished).ToListAsync();

        if (result.Any())
        {
            return result.OrderBy(o => o.CreationTime)
                .Select(e => e.DeserializeJsonContent(_eventTypes.Find(t => t.Name == e.EventTypeShortName)));
        }

        return new List<IntegrationEventLogEntry>();
    }

    public Task SaveEventAsync(IntegrationEvent @event, IDbContextTransaction transaction)
    {
        if (transaction == null) throw new ArgumentNullException(nameof(transaction));

        var eventLogEntry = new IntegrationEventLogEntry(@event, transaction.TransactionId);

        _integrationEventLogContext.Database.UseTransaction(transaction.GetDbTransaction());
        _integrationEventLogContext.IntegrationEventLogs.Add(eventLogEntry);

        return _integrationEventLogContext.SaveChangesAsync();
    }

    public Task MarkEventAsPublishedAsync(Guid eventId)
    {
        return UpdateEventStatus(eventId, EventStateEnum.Published);
    }

    public Task MarkEventAsInProgressAsync(Guid eventId)
    {
        return UpdateEventStatus(eventId, EventStateEnum.InProgress);
    }

    public Task MarkEventAsFailedAsync(Guid eventId)
    {
        return UpdateEventStatus(eventId, EventStateEnum.PublishedFailed);
    }

    private Task UpdateEventStatus(Guid eventId, EventStateEnum status)
    {
        var eventLogEntry = _integrationEventLogContext.IntegrationEventLogs.Single(ie => ie.EventId == eventId);
        eventLogEntry.State = status;

        if (status == EventStateEnum.InProgress)
            eventLogEntry.TimesSent++;

        _integrationEventLogContext.IntegrationEventLogs.Update(eventLogEntry);

        return _integrationEventLogContext.SaveChangesAsync();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                _integrationEventLogContext?.Dispose();
            }


            _disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
