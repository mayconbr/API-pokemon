
using Microsoft.AspNetCore.Mvc;
namespace Pokedex.Controllers
{
    public class LoginController : Controller
    {
        private readonly JwtTokenService _jwtTokenService;

        public IActionResult Index()
        {
            return View();
        }

        public LoginController(JwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest.Username == "admin" && loginRequest.Password == "password")
            {
                // Dados do usu�rio para os claims
                string userId = "1";           
                string username = "admin";     
                string role = "Admin";         

                // Gera o token JWT
                var token = _jwtTokenService.GenerateToken(userId, username, role);

                // Configura��o do cookie
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,                // Protege contra acesso via JavaScript
                    Secure = true,                  // Somente enviar via HTTPS
                    SameSite = SameSiteMode.Strict, // Bloqueia envio do cookie para outros dom�nios
                    Expires = DateTime.UtcNow.AddMinutes(60) // Expira��o do cookie
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

            return Unauthorized(new { Message = "Usu�rio ou senha inv�lidos" });
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
