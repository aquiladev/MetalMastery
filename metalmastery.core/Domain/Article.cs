using System;

namespace MetalMastery.Core.Domain
{
    public class Article : BaseEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime CreateDate { get; set; }

        public Guid OwnerId { get; set; }

        public bool IsPublished { get; set; }

        public virtual User Owner { get; set; }
    }
}
