using Pokedex.Models;
using Pokedex;
using Pokedex.Interfaces;

public class LoginRepository : IPokemonRepository
{
    private readonly Context _context;

    public LoginRepository(Context context)
    {
        _context = context;
    }

}
