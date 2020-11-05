using System.Collections.Generic;

namespace Komar.Shared.Entities
{
    public class Brand : Trackable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Material> Materials { get; } = new List<Material>();
    }
}
