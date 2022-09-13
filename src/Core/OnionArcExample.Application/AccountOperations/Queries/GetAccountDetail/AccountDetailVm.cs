using System;

namespace OnionArcExample.Application.AccountOperations.Queries.GetAccountDetail
{
    public class AccountDetailVm
    {
        public virtual int Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string Role { get; set; }
        public virtual DateTime LastActivity { get; set; }
    }
}
