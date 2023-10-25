using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_university_labor_exchange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthenticationController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IConfiguration configuration, IAuthenticationService authenticationService)
        {
            _configuration = configuration;
            _authenticationService = authenticationService;
        }

        [HttpPost("Authenticate")]
        public ActionResult<string> Autenticar([FromBody] Credentials credentials) 
        {
            
            User user = Authenticate(credentials); 

            if (user is null) //Si el la función de arriba no devuelve nada es porque los datos son incorrectos, por lo que devolvemos un Unauthorized (un status code 401).
                return Unauthorized();

            //Crear el token
            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"])); //Traemos la SecretKey del Json. agregar antes: using Microsoft.IdentityModel.Tokens;

            var credential = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            //Los claims son datos en clave->valor que nos permite guardar data del usuario.
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.IdUser.ToString())); //"sub" es una key estándar que significa unique user identifier, es decir, si mandamos el id del usuario por convención lo hacemos con la key "sub".
            claimsForToken.Add(new Claim("email", user.Email)); //Lo mismo para given_name y family_name, son las convenciones para nombre y apellido. Ustedes pueden usar lo que quieran, pero si alguien que no conoce la app
            claimsForToken.Add(new Claim("username", user.Username)); //quiere usar la API por lo general lo que espera es que se estén usando estas keys.
            claimsForToken.Add(new Claim("role", user.UserType)); //Debería venir del usuario
            claimsForToken.Add(new Claim("state", user.State.ToString()));

            var jwtSecurityToken = new JwtSecurityToken( //agregar using System.IdentityModel.Tokens.Jwt; Acá es donde se crea el token con toda la data que le pasamos antes.
              _configuration["Authentication:Issuer"],
              _configuration["Authentication:Audience"],
              claimsForToken,
              DateTime.UtcNow,
              DateTime.UtcNow.AddHours(1),
              credential);

            var tokenToReturn = new JwtSecurityTokenHandler() //Pasamos el token a string
                .WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);
        }
        private User? Authenticate(Credentials credentials)
        {
            return _authenticationService.ValidateUser(credentials.Email, credentials.Password);
        }
    }
}
