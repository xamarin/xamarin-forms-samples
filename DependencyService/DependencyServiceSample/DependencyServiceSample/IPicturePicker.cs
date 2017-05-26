using System;
using System.IO;
using System.Threading.Tasks;

namespace DependencyServiceSample
{
    public interface IPicturePicker
    {
        Task<Stream> GetImageStreamAsync();
    }
}
