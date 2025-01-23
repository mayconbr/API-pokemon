using Pokedex.Models;
namespace Pokedex.Interfaces
{
    public interface IPokemonRepository
    {
        Pokemon InsertPokemon(Pokemon request);
    }
}