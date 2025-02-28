using DomainLayer.Sesion;
using InfrastructureLayer.Repositorio.UsuarioRepositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Generators;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DomainLayer.Models;
using BCrypt.Net;

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
        public IActionResult Login([FromBody] Login logueo)
        {
            var usuario = _usuarioRepositorio.ObtenerUsuarioPorNombre(logueo.Nombre);

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(logueo.Contrasena, usuario.Contrasena))
            {
                return Unauthorized("Credenciales incorrectas");
            }

            var token = GenerateJwtToken(usuario.Nombre, usuario.Role);
            return Ok(new { Token = token });
        }

        private string GenerateJwtToken(string Nombre, string roll)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, Nombre),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, roll)
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

