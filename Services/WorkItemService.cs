using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JsonApiDemo.Models;
using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Services;

namespace JsonApiDemo.Services
{
    public sealed class WorkItemService : IResourceService<WorkItem>
    {
        private static readonly Dictionary<int, WorkItem> _workItems = new();
        private static int lastId;

        public async Task<IReadOnlyCollection<WorkItem>> GetAsync(CancellationToken cancellationToken)
        {
            return _workItems.Values;
        }

        public async Task<WorkItem> GetAsync(int id, CancellationToken cancellationToken)
        {
            return _workItems.ContainsKey(id) ? _workItems[id] : null;
        }

        public async Task<WorkItem> CreateAsync(WorkItem resource, CancellationToken cancellationToken)
        {
            resource.Id = ++lastId;
            _workItems.Add(resource.Id, resource);
            return resource;
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            _workItems.Remove(id);
        }

        public Task AddToToManyRelationshipAsync(int primaryId, string relationshipName,
            ISet<IIdentifiable> secondaryResourceIds,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<WorkItem> UpdateAsync(int id, WorkItem resource, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetRelationshipAsync(int primaryId, string relationshipName, object secondaryResourceIds,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromToManyRelationshipAsync(int primaryId, string relationshipName,
            ISet<IIdentifiable> secondaryResourceIds,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetRelationshipAsync(int id, string relationshipName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetSecondaryAsync(int id, string relationshipName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
