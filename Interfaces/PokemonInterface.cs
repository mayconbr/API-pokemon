using Pokedex.Models;
namespace Pokedex.Interfaces
{
    public interface IPokemonRepository
    {
        Pokemon InsertPokemon(Pokemon request);
        Pokemon UpdatePokemon(Pokemon request);
        Pokemon GetPokemonById(long id);
        List<Pokemon> GetPokemonsByTrainer(long id);

    }
}