
using System.Threading.Tasks;

namespace JuniorMath.ApplicationCore.Interfaces.Base
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
