using System.Security.Principal;

namespace MvcPL.Infrastructure.Principal
{
    public class CustomPrincipal : ICustomPrincipal
    {
        public bool IsInRole(string role)
        {
            throw new System.NotImplementedException();
        }

        public IIdentity Identity { get; }
        public int Id { get; set; }
        public string Email { get; set; }
    }
}