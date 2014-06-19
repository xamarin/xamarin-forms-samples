using System;
using System.Threading.Tasks;

namespace MobileCRM.Services
{
    public interface IAuthenticationService
    {
        Task<IAuthenticationResponse> TryCredentials(string identifier, string secret);
    }
}
