using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MvcPL.Infrastructure.Principal
{
    public interface ICustomPrincipal : IPrincipal
    {
        int Id { get; set; }
    }
}
