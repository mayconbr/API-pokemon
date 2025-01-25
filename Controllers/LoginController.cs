
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
    /// Endpoint para login e geração de token JWT.
    /// </summary>
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest loginRequest)
    {
        // Simulação de validação de usuário (substitua com sua lógica)
        if (loginRequest.Username == "admin" && loginRequest.Password == "password")
        {
            // Dados do usuário para os claims
            string userId = "1";           // ID do usuário (exemplo)
            string username = "admin";     // Nome de usuário
            string role = "Admin";         // Role/papel do usuário

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
/// Modelo de requisição para login.
/// </summary>
public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}
