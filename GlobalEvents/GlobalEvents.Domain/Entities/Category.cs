﻿using GlobalEvents.Domain.Common;

namespace GlobalEvents.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Event> Events { get; set; }
    }
}
