using System;

namespace Framework.Core.Entities
{
    public abstract class BaseEntity
    {
        public DateTime? DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public DateTime? DateDeleted { get; set; }
    }
}