using System.Threading.Tasks;

namespace TodoAzure
{
    public interface IAuthenticate
    {
        Task<bool> LoginAsync(bool useSilent = false);

        Task<bool> LogoutAsync();
    }
}
