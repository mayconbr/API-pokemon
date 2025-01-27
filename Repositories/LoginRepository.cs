using Pokedex.Models;
using Pokedex;
using Pokedex.Interfaces;

public class LoginRepository : ILoginInterface
{
    private readonly Context _context;

    public LoginRepository(Context context)
    {
        _context = context;
    }

    public User GetUser(User user)
    {
        try
        {
            var FindUser = _context.Users.FirstOrDefault(p => p == user);

            if (FindUser == null) 
            {
                throw new Exception("Usuário não encontrado!");
            }

            return FindUser;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao buscar usuário: {ex.Message}");
        }
    }


}
