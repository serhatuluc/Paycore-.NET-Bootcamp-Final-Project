using System;

namespace OnionArcExample.Application
{
    public class BadRequestException:ApplicationException
    {
        public BadRequestException(string message) : base(message)
        {

        }
    }
}
