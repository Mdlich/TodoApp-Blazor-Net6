using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TodoApp.API.Data;
using TodoApp.API.Models;
using TodoApp.API.Models.User;

namespace TodoApp.API.Configurations
{
	public class MapperConfig : Profile
	{
		public MapperConfig()
		{
			CreateMap<TodoWriteDto, Todo>().ReverseMap();
			CreateMap<TodoReadDto, Todo>().ReverseMap();
			CreateMap<IdentityUser, UserDto>().ReverseMap();
		}
	}
}
