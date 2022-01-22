using System.ComponentModel.DataAnnotations;

namespace TodoApp.API.Models.User
{
	public class UserDto : LoginUserDto
	{
		[Required]
		public string Role { get; set; }
	}
}