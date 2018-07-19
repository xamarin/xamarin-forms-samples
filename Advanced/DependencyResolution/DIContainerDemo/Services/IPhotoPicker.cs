using System.IO;
using System.Threading.Tasks;

namespace DIContainerDemo
{
    public interface IPhotoPicker
    {
        Task<Stream> GetImageStreamAsync();
    }
}
