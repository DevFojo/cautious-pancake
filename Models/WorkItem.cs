using System;
using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;

namespace JsonApiDemo.Models
{
    public sealed class WorkItem : Identifiable
    {
        [Attr]
        public bool IsBlocked { get; set; }

        [Attr]
        public string Title { get; set; }

        [Attr]
        public long DurationInHours { get; set; }

        [Attr]
        public Guid ProjectId { get; set; } = Guid.NewGuid();
    }
}
