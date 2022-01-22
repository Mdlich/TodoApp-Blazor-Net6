using System.ComponentModel.DataAnnotations;

namespace TodoApp.API.Models
{
	public class TodoReadDto
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
	}
}
