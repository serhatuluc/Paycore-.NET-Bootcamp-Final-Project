using OnionArcExample.Domain.Entities;

namespace OnionArcExample.Domain
{
    public class Author:BaseEntity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
    }
}
