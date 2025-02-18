using Pokedex.Models;
using System.Threading.Tasks;
namespace Pokedex.Interfaces
{
    public interface IUserInterface
    {
        Task<User?> GetUser(User user);
        Task<User?> GetUserById(long Id);
    }
}