﻿using Pokedex.Models;
namespace Pokedex.Interfaces
{
    public interface ITreinadorepository
    {
        Trainer InsertTrainer(Trainer request);
        Task<Trainer> UpdateTrainer(Trainer request);
        Task<Trainer> GetTrainerById(long Id);
        Task<Trainer> DeleteTrainer(long Id);
    }
}