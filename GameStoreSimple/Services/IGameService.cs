using System.Threading.Tasks;

namespace MVC.Services
{
    public interface IGameService
    {
        Task<bool> CreateGameAsync();
    }
}