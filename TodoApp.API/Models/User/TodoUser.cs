using Microsoft.AspNetCore.Identity;
using TodoApp.API.Data;

namespace TodoApp.API.Models.User
{
	public class TodoUser: IdentityUser
	{
		public virtual ICollection<Todo> Todos { get; set; }

		public TodoUser()
		{
			Todos = new HashSet<Todo>();
		}
	}
}
