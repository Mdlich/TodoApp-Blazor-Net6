using AutoMapper;
using TodoApp.API.Data;
using TodoApp.API.Models;

namespace TodoApp.API.Configurations
{
	public class MapperConfig : Profile
	{
		public MapperConfig()
		{
			CreateMap<TodoWriteDto, Todo>().ReverseMap();
			CreateMap<TodoReadDto, Todo>().ReverseMap();
		}
	}
}
