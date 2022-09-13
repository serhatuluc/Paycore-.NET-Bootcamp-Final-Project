using OnionArcExample.Domain.Entities;
using System.Collections.Generic;

namespace OnionArcExample.Domain
{
    public class Author:BaseEntity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual int AccountId { get; set; }    
    }
}
