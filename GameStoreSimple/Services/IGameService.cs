using System.Threading.Tasks;

namespace GameStoreSimple.Services
{
    public interface IGameService
    {
        Task<bool> CreateGameAsync();
    }
}