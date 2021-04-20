using System.Threading.Tasks;

namespace MediaElementDemos
{
    public interface IVideoPicker
    {
        Task<string> GetVideoFileAsync();
    }
}
