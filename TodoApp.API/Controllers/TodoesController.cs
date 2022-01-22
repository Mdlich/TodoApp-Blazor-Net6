#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.API.Data;
using TodoApp.API.Models;
using TodoApp.API.Static;

namespace TodoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoesController : ControllerBase
    {
        private readonly TodoDBContext _context;
		private readonly IMapper mapper;
		private readonly ILogger<TodoesController> logger;

		public TodoesController(TodoDBContext context, IMapper mapper, ILogger<TodoesController> logger)
        {
            _context = context;
			this.mapper = mapper;
            this.logger = logger;
		}

        // GET: api/Todoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoReadDto>>> GetTodos()
        {
			try
			{
                var todoes = mapper.Map<IEnumerable<TodoReadDto>>(await _context.Todos.ToListAsync());
                return Ok(todoes);
			}
			catch (Exception e)
			{
                logger.LogError(e, $"Error Performing GET in {nameof(GetTodos)}");
				return StatusCode(500, Messages.Error500Message);
			}
        }

		// GET: api/Todoes/5
		[HttpGet("{id}")]
		public async Task<ActionResult<TodoReadDto>> GetTodo(int id)
        {
			try
			{
                var todo = await _context.Todos.FindAsync(id);
                var todoDto = mapper.Map<TodoReadDto>(todo);
            
                if (todoDto == null)
                {
                    logger.LogWarning($"Record not found at {nameof(GetTodo)}. Id: {id}.");
                    return NotFound();
                }

                return Ok(todoDto);
			}
			catch (Exception e)
			{
                logger.LogError(e, $"Error Performing GET in {nameof(GetTodos)}");
                return StatusCode(500, Messages.Error500Message);
			}
        }

        // PUT: api/Todoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodo(int id, TodoWriteDto todoDto)
        {
            var todo = await _context.Todos.FindAsync(id);
            if(todo == null)
			{
                logger.LogWarning($"Record not found at {nameof(PutTodo)}. Id: {id}.");
                return NotFound();
            }

            mapper.Map(todoDto, todo);
            _context.Entry(todo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (! await TodoExists(id))
                {
                    logger.LogWarning($"Record not found at {nameof(PutTodo)}. Id: {id}.");
                    return NotFound();
                }
                else
                {
                    logger.LogError(e, $"Error performing {nameof(PutTodo)}. Id: {id}.");
                    return StatusCode(500, Messages.Error500Message);
                }
            }

            return NoContent();
        }

        // POST: api/Todoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoReadDto>> PostTodo(TodoWriteDto todoDto)
        {
			try
			{
                var todo = mapper.Map<Todo>(todoDto);
                _context.Todos.Add(todo);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetTodo), new { id = todo.Id }, todo);
			}
			catch (Exception e)
			{
                logger.LogError(e, $"Error performing {nameof(PutTodo)}", todoDto);
                return StatusCode(500, Messages.Error500Message);
            }
        }

        // DELETE: api/Todoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
			try
			{
                var todo = await _context.Todos.FindAsync(id);
                if (todo == null)
                {
                    logger.LogWarning($"Record not found at {nameof(DeleteTodo)}. Id: {id}.");
                    return NotFound();
                }

                _context.Todos.Remove(todo);
                await _context.SaveChangesAsync();

                return NoContent();
			}
			catch (Exception e)
			{
                logger.LogError(e, $"Error performing {nameof(DeleteTodo)}. Id: {id}.");
                return StatusCode(500, Messages.Error500Message);
            }
        }

        private async Task<bool> TodoExists(int id)
        {
            logger.LogWarning($"Record not found at {nameof(TodoExists)}. Id: {id}.");
            return await _context.Todos.AnyAsync(e => e.Id == id);
        }
    }
}
