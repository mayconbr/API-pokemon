﻿using Pokedex.Models;
namespace Pokedex.Interfaces
{
    public interface ILoginInterface
    {
        User GetUser(User request);
    }
}