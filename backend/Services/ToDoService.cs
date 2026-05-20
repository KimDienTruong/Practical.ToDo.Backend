using backend.Data;
using backend.DTO;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class ToDoService
    {
        private readonly ApplicationDbContext _context;
        public ToDoService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<GetToDosResponseDTO> GetToDoTasksWithPagination(string username, int pageIndex, int pageSize)
        {
            IEnumerable<ToDoTask> toDoTasks = await _context.ToDoTasks.Where(x => x.UserName == username).Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();

            if (!toDoTasks.Any())
            {

            }

            int total = await _context.ToDoTasks.Where(x => x.UserName == username).CountAsync();

            return new GetToDosResponseDTO(toDoTasks, total, pageIndex, pageSize);
        }

        public async Task<ToDoTask?> CreateToDo(CreateToDoDTO createToDoDTO)
        {
            ToDoTask toDoTask = new ToDoTask(createToDoDTO.Title, createToDoDTO.Description, createToDoDTO.UserName);

            try
            {
                await _context.ToDoTasks.AddAsync(toDoTask);
                await _context.SaveChangesAsync();
                return toDoTask;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ToDoTask?> UpdateToDo(string id, UpdateToDoDto updateToDoDto)
        {
            ToDoTask? toDoTask = await _context.ToDoTasks.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (toDoTask == null)
            {
                return toDoTask;
            }

            toDoTask.UpdateToDo(updateToDoDto.Title, updateToDoDto.Description, updateToDoDto.Progress);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch { }

            return toDoTask;
        }

        public async Task<bool> DeleteToDo(string id)
        {
            ToDoTask? toDoTask = await _context.ToDoTasks.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (toDoTask == null)
            {
                return false;
            }

            toDoTask.IsDeleted = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
