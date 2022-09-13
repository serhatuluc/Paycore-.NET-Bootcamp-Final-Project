using MediatR;
using OnionArcExample.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcExample.Application.AuthorOperations
{
    public class DeleteAuthorCommand:IRequest
    {
        public int Id { get; set; }

    }
}
