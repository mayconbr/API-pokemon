using Pokedex.Models;
namespace Pokedex.Interfaces
{
    public interface ILoginInterface
    {
        Task<User?> GetUser(User user);
    }
}