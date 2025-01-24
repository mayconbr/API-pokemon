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
                trainerId = request.trainerId,
                pokemon = request.pokemon,
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
            throw;
        }
    }

    public Pokemon UpdatePokemon(Pokemon request)
    {
        try
        {
            var pokemon = _context.Pokemons.FirstOrDefault(p => p.id == request.id);

            if (pokemon == null)
            {
                throw new Exception("Pokémon não encontrado!");
            }
            else
            {
                pokemon.name = request.name;

                _context.Pokemons.Update(pokemon);
                _context.SaveChanges();

                return pokemon;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public List<Pokemon> GetPokemonsByTrainer(long id)
    {
        try
        {          
            var pokemons = _context.Pokemons.Where(p => p.trainerId == id).ToList();
          
            if (pokemons == null || !pokemons.Any())
            {
                throw new Exception("Nenhum Pokémon encontrado para este treinador!");
            }

            return pokemons; 
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao buscar Pokémon: {ex.Message}");
        }
    }


    public Pokemon GetPokemonById(long id)
    {
        try
        {
            var pokemon = _context.Pokemons.FirstOrDefault(p => p.id == id);

            if (pokemon == null)
            {
                throw new Exception("Pokémon não encontrado!");
            }

            return pokemon;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao buscar Pokémon: {ex.Message}");
        }
    }
}
