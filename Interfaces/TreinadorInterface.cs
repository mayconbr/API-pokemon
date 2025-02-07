using Pokedex.Models;
namespace Pokedex.Interfaces
{
    public interface ITreinadorepository
    {
        Trainer InsertTrainer(Trainer request);
    }
}