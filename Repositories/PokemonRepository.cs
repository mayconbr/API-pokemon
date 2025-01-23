using Pokedex.Models;
using Pokedex;
using Pokedex.Interfaces;

public class PokemonRepository : IPokemonRepository
{
    private readonly Context _context;

    public PokemonRepository(Context context)
    {
        _context = context;
    }

    public Pokemon InsertPokemon(Pokemon request)
    {
        try
        {
            var newPokemon = new Pokemon
            {
                name = request.name,
                pokedexNumber = request.pokedexNumber,
                type = request.type
            };

            _context.Pokemons.Add(newPokemon);
            _context.SaveChanges();

            return newPokemon;
        }
        catch (Exception)
        {
            throw; // Deixa a exceção ser tratada pelo controller
        }
    }
}
