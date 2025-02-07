﻿using Microsoft.EntityFrameworkCore;
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

        public Trainer InsertTrainer(Trainer request)
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

        public  async Task <Trainer> UpdateTrainer(Trainer request)
        {
            try
            {
                var trainer = await _context.Treiners.FirstOrDefaultAsync(x => x.id == request.id);

                if (trainer == null)
                {
                    throw new Exception("Treinador não encontrado.");
                }

                trainer.userId = request.userId;
                trainer.name = request.name;
                trainer.region = request.region;
                trainer.creationDate = request.creationDate;
                _context.SaveChanges();

                return trainer;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
