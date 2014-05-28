using System;
using MobileCRM.Services;

namespace MobileCRM.Services
{
    public interface IAuthenticationResponse
    {
        IAuthenticationService Sender { get; }
        bool IsAuthenticated { get; }
        string Message { get; }
    }
}

