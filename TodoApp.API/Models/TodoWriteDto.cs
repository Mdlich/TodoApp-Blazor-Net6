using System.ComponentModel.DataAnnotations;

namespace TodoApp.API.Models
{
	public class TodoWriteDto
	{
		[Required]
		[StringLength(50)]
		public string? Name { get; set; }
		[StringLength(500)]
		public string? Description { get; set; }
	}
}
