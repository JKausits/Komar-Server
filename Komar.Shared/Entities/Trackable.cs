using System;

namespace Komar.Shared.Entities
{
    public abstract class Trackable
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
