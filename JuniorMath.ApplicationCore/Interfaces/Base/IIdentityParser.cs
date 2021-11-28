using System.Security.Principal;

namespace JuniorMath.ApplicationCore.Interfaces.Base
{
    public interface IIdentityParser<T>
    {
        T Parse(IPrincipal principal);
    }
}
