
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly JwtTokenService _jwtTokenService;

    public AuthController(JwtTokenService jwtTokenService)
    {
        _jwtTokenService = jwtTokenService;
    }

    /// <summary>
    /// Endpoint para login e gera��o de token JWT.
    /// </summary>
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest loginRequest)
    {
        // Simula��o de valida��o de usu�rio (substitua com sua l�gica)
        if (loginRequest.Username == "admin" && loginRequest.Password == "password")
        {
            // Dados do usu�rio para os claims
            string userId = "1";           // ID do usu�rio (exemplo)
            string username = "admin";     // Nome de usu�rio
            string role = "Admin";         // Role/papel do usu�rio

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

    /// <summary>
    /// Endpoint para logout (remove o cookie do cliente).
    /// </summary>
    [HttpPost("logout")]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("jwt"); // Remove o cookie do cliente
        return Ok(new { Message = "Logout realizado com sucesso" });
    }
}

/// <summary>
/// Modelo de requisi��o para login.
/// </summary>
public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}
