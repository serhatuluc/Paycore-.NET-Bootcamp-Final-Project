using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcExample.Application.Common.Exceptions
{
    public class CredentialException : ApplicationException
    {
        public CredentialException (string message) : base(message)
        {

        }
    }
}
