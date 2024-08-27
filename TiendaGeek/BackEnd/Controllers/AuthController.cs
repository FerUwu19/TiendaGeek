using BackEnd.Model;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenService TokenService;

        public AuthController(UserManager<IdentityUser> userManager,
                                ITokenService tokenService)
        {
            this.userManager = userManager;
            this.TokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            IdentityUser user = await userManager.FindByNameAsync(model.Username);
            LoginModel Usuario = new LoginModel();
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                try
                {
                    var jwtToken = TokenService.CreateToken(user, userRoles.ToList());

                    Usuario.Token = jwtToken;
                    Usuario.Roles = userRoles.ToList();
                    Usuario.Username = user.UserName;
                }
                catch (SecurityTokenException ex)
                {
                    return StatusCode(500, "Error al crear el token: " + ex.Message);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Error interno: " + ex.Message);
                }

                return Ok(Usuario);
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);

            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });
            }

            IdentityUser user = new IdentityUser
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                {
                    Status = "Error",
                    Message = string.Join(", ", result.Errors.Select(e => e.Description))
                });
            }


            return Ok(new Response { Status = "Success", Message = "Usuario Creado" });
        }
        [HttpGet("{username}")]
        public async Task<IActionResult> GetPerfil(string username)
        {
            // Encuentra al usuario por su nombre de usuario
            var user = await userManager.FindByNameAsync(username);

            if (user == null)
            {
                return NotFound("Usuario no encontrado.");
            }

            // Aquí se asume que tienes un modelo de perfil en BackEnd.Model, como UserModel
            var perfil = new UserModel
            {
                UserName = user.UserName,
                Email = user.Email,
                // Si tienes propiedades adicionales en el modelo de usuario, añádelas aquí
                // Nombre = user.Nombre,
                // Apellido = user.Apellido,
                // FotoPerfil = user.FotoPerfil
            };

            return Ok(perfil);
        }

        [HttpPost]
        [Route("logout")]
        public IActionResult Logout()
        {
            // Lógica para cerrar sesión
            return Ok(new Response { Status = "Success", Message = "Logged out successfully" });
        }


    }
}
