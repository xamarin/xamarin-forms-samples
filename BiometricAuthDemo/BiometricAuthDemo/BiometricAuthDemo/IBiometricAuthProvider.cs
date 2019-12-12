using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BiometricAuthDemo
{
    public interface IBiometricAuthProvider
    {
        bool IsBiometricAuthEnabled { get; }

        void RequestAuthentication(Action<BiometricAuthResult> completionCallback);
    }
}
