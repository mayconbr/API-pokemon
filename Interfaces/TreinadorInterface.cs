using Pokedex.Models;
namespace Pokedex.Interfaces
{
    public interface ITreinadorepository
    {
        Trainer InsertTrainer(Trainer request);
        Task<Trainer> UpdateTrainer(Trainer request);
    }
}