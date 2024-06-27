using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RevenueRecognitionSystem.Contexts;
using RevenueRecognitionSystem.Helpers;
using RevenueRecognitionSystem.Models;
using RevenueRecognitionSystem.RequestModels;
using RevenueRecognitionSystem.ResponseModels;

namespace RevenueRecognitionSystem.Controllers;

[ApiController]
[Route("api/authentication")]
public class UserController(IConfiguration configuration, DatabaseContext dbContext) : ControllerBase
{

    [AllowAnonymous]
    [HttpPost("register")]
    public IActionResult RegisterUser(RegisterRequestModel model)
    {
        var hashedPasswordAndSalt = SecurityHelpers.GetHashedPasswordAndSalt(model.Password);

        var user = new User
        {
            Login = model.Login,
            Password = hashedPasswordAndSalt.Item1,
            Salt = hashedPasswordAndSalt.Item2,
            Role = model.Role
        };

        dbContext.Users.Add(user);
        dbContext.SaveChanges();

        return Ok();
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public IActionResult Login(LoginRequestModel model)
    {
        User user = dbContext.Users.Where(u => u.Login == model.Login).FirstOrDefault();
        
        var passwordHashFromDb = user.Password;
        var currentHashedPassword = SecurityHelpers.GetHashedPasswordWithSalt(model.Password, user.Salt);

        if (passwordHashFromDb != currentHashedPassword)
        {
            return Unauthorized();
        }

        var userclaim = new[]
        {
            new Claim(ClaimTypes.Name, user.Login),
            new Claim(ClaimTypes.Role, user.Role.ToLower())
        };

        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]!));
        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken token = new JwtSecurityToken(
            issuer: configuration["JWT:Issuer"],
            audience: configuration["JWT:Audience"],
            claims: userclaim,
            expires: DateTime.Now.AddMinutes(15),
            signingCredentials: creds
        );

        dbContext.SaveChanges();

        return Ok(new LoginResponseModel
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
        });
    }
}