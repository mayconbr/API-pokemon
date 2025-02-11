using Pokedex.Models;
using Pokedex;
using Pokedex.Interfaces;
using Microsoft.EntityFrameworkCore;

public class LoginRepository : ILoginInterface
{
    private readonly Context _context;
}
