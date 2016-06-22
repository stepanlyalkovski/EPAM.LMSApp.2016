using System.Security.Principal;

namespace MvcPL.Infrastructure.Principal
{
    public class CustomPrincipal : ICustomPrincipal
    {
        public IIdentity Identity { get; private set; }

        public bool IsInRole(string role)
        {
            throw new System.NotImplementedException();
        }

        
        public int Id { get; set; }
        public string Email { get; set; }
    }
}