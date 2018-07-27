using System.IO;
using System.Threading.Tasks;

namespace FactoriesDemo
{
    public interface IPhotoPicker
    {
        Task<Stream> GetImageStreamAsync();
    }
}
