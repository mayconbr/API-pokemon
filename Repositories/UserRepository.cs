using Pokedex.Models;
using Pokedex;
using Pokedex.Interfaces;
using Microsoft.EntityFrameworkCore;

public class UserRepository : ILoginInterface
{
    private readonly Context _context;

    public UserRepository(Context context)
    {
        _context = context;
    }

    public async Task<User?> GetUser(User user)
    {
        try
        {
            var findUser = await _context.Users.FirstOrDefaultAsync(u => u == user);

            return findUser;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao buscar usuário: {ex.Message}", ex);
        }
    }
}
