using Microsoft.EntityFrameworkCore;
using Pokedex.Interfaces;
using Pokedex.Models;

namespace Pokedex.Repositories
{
    public class TreinadorRepository : ITreinadorepository
    {
        private readonly Context _context;

        public TreinadorRepository(Context context)
        {
            _context = context;
        }

        public Pokemon InsertTreinador(Pokemon request)
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
    }
}
