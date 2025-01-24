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

        public Trainer InsertTreinador(Trainer request)
        {
            try
            {
                var newTrainer = new Trainer
                {
                    userId =  request.userId,
                    name = request.name,
                    region = request.region,
                    creationDate = request.creationDate,                            
                };

                _context.Treiners.Add(newTrainer);
                _context.SaveChanges();

                return newTrainer;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
