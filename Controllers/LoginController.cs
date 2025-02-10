
using Microsoft.AspNetCore.Mvc;
using Pokedex.Models;
namespace Pokedex.Controllers
{
    public class LoginController : Controller
    {
        private readonly JwtTokenService _jwtTokenService;
        private readonly LoginRepository _loginRepository;

        public LoginController(JwtTokenService jwtTokenService, LoginRepository loginRepository)
        {
            _jwtTokenService = jwtTokenService;
            _loginRepository = loginRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User request)
        {
            var findUser = await _loginRepository.GetUser(request);

            if (findUser != null)
            {
                // Dados do usuário para os claims
                string userId = "1";           
                string username = "admin";     
                string role = "Admin";         

                // Gera o token JWT
                var token = _jwtTokenService.GenerateToken(userId, username, role);

                // Configuração do cookie
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,                // Protege contra acesso via JavaScript
                    Secure = true,                  // Somente enviar via HTTPS
                    SameSite = SameSiteMode.Strict, // Bloqueia envio do cookie para outros domínios
                    Expires = DateTime.UtcNow.AddMinutes(60) // Expiração do cookie
                };

                // Adiciona o token ao cookie
                Response.Cookies.Append("jwt", token, cookieOptions);

                return Ok(new
                {
                    Message = "Login realizado com sucesso",
                    Username = username,
                    Role = role
                });
            }

            return Unauthorized(new { Message = "Usuário ou senha inválidos" });
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return Ok(new { Message = "Logout realizado com sucesso" });
        }
    }
}

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}
