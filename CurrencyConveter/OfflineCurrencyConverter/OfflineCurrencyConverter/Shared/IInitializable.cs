using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OfflineCurrencyConverter.Shared
{
    /// <summary>
    /// Represents an object which has to be initilized
    /// After its instantiation, and before use
    /// This initialization is sometimes asynchronous
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IInitializable<T>
    {
        Task InitializeAsync();
        Task StopAsync();
    }
}
