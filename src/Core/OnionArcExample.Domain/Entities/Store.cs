using OnionArcExample.Domain.Entities;
using System.Collections.Generic;

namespace OnionArcExample.Domain
{
    public class Store:BaseEntity
    { 
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual int Inventory { get; set; }
    }
}
