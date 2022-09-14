using OnionArcExample.Domain.Entities;
using System;
using System.Collections.Generic;

namespace OnionArcExample.Domain
{
    public class Account:BaseEntity
    {
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string Role { get; set; } = "Viewer";
        public virtual DateTime LastActivity { get; set; }

    }
}
