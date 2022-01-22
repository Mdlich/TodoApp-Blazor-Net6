using System.ComponentModel.DataAnnotations;

namespace TodoApp.API.Models.User
{
	public class LoginUserDto
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
	}
}