using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TodoApp.API.Models.User;

namespace TodoApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly ILogger<AuthController> logger;
		private readonly IMapper mapper;
		private readonly UserManager<IdentityUser> userManager;
		private readonly IConfiguration config;

		public AuthController(ILogger<AuthController> logger, IMapper mapper, UserManager<IdentityUser> userManager, IConfiguration config)
		{
			this.mapper = mapper;
			this.userManager = userManager;
			this.config = config;
			this.logger = logger;
		}

		[HttpPost]
		[Route("register")]
		public async Task<IActionResult> Register(UserDto userDto)
		{
			var user = mapper.Map<IdentityUser>(userDto);
			user.UserName = userDto.Email;
			var result = await userManager.CreateAsync(user, userDto.Password);
			logger.LogInformation($"Registration attempt for {userDto.Email}");

			try
			{
				if (!result.Succeeded)
				{
					foreach (var error in result.Errors)
					{
						ModelState.AddModelError(error.Code, error.Description);
					}
					return BadRequest(ModelState);
				}

				await userManager.AddToRoleAsync(user, userDto.Role);
				return Accepted();
			}
			catch (Exception e)
			{
				logger.LogError(e, $"Something went wrong at {nameof(Register)}");
				return Problem($"Something went wrong at {nameof(Register)}", statusCode: 500);
			}
		}

		[HttpPost]
		[Route("login")]
		public async Task<ActionResult<AuthResponse>> Login(LoginUserDto userDto)
		{
			logger.LogInformation($"Login attempt for {userDto.Email}");
			try
			{
				var user = await userManager.FindByEmailAsync(userDto.Email);
				var passwordValid = await userManager.CheckPasswordAsync(user, userDto.Password);
				if(user == null || passwordValid == false)
				{
					logger.LogWarning($"user {userDto.Email} is not registered or wrong password.");
					return Unauthorized(userDto);
				}

				string tokenString = await GenerateToken(user);

				var response = new AuthResponse
				{
					Email = userDto.Email,
					Token = tokenString,
					UserId = user.Id
				};

				return response;
			}
			catch (Exception e)
			{
				logger.LogError(e, $"Something went wrong at {nameof(Login)}");
				return Problem($"Something went wrong at {nameof(Login)}", statusCode: 500);
			}
		}

		private async Task<string> GenerateToken(IdentityUser user)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Key"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var roles = await userManager.GetRolesAsync(user);
			var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role, q));

			var userClaims = await userManager.GetClaimsAsync(user);

			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				new Claim("uid", user.Id),
			}
			.Union(userClaims)
			.Union(roleClaims);

			var token = new JwtSecurityToken(
				issuer: config["JwtSettings:Issuer"],
				audience: config["JwtSettings:Audience"],
				claims: claims,
				expires: DateTime.UtcNow.AddHours(int.Parse(config["JwtSettings:Duration"])),
				signingCredentials: credentials
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}

}
