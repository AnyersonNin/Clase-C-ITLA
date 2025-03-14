using DomainLayer.Sesion;
using InfrastructureLayer.Repositorio.UsuarioRepositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace GestorTareasAPI.Controllers
{
    [Route("api/Autentificar")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UsuarioRepositorio _usuarioRepositorio;

        public LoginController(IConfiguration configuration, UsuarioRepositorio usuarioRepositorio)
        {
            _configuration = configuration;
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(Login model)
        {
            var usuario = await _usuarioRepositorio.ObtenerPorNombre(model.Nombre);

            if (usuario == null || usuario.Contrasena != model.Contrasena)
            {
                return Unauthorized(new { mensaje = "Credenciales incorrectas" });
            }

            var token = GenerateJwtToken(usuario.Nombre, usuario.Role);

            return Ok(new { token });
        }

        private string GenerateJwtToken(string nombre, string rol)
        {
            var key = _configuration["Jwt:Key"];

            if (string.IsNullOrEmpty(key) || key.Length < 32)
            {
                throw new Exception("La clave JWT es demasiado corta. Debe tener al menos 32 caracteres.");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, nombre),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(ClaimTypes.Role, rol)
    };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

    


