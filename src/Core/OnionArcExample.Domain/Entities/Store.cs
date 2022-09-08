using OnionArcExample.Domain.Entities;

namespace OnionArcExample.Domain
{
    public class Store:BaseEntity
    { 
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual int Inventory { get; set; }
    }
}
