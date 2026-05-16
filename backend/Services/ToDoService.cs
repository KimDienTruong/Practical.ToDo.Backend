using backend.Data;
using backend.DTO;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class ToDoService
    {
        private readonly ApplicationDbContext _context;

        public ToDoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<ToDoTask>> GetToDoTasksWithPagination(int pageIndex, int pageSize)
        {
            ICollection<ToDoTask> toDoTasks = await _context.ToDoTasks.Skip(pageIndex).Take(pageSize).ToListAsync();

            return toDoTasks;
        }

        public async Task<ToDoTask?> CreateToDo(CreateToDoDTO createToDoDTO)
        {
            ToDoTask toDoTask = new ToDoTask(createToDoDTO.Title, createToDoDTO.Description, createToDoDTO.UserName);

            try
            {
                await _context.ToDoTasks.AddAsync(toDoTask);
                return toDoTask;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ToDoTask?> UpdateToDo(string id, UpdateToDoDto updateToDoDto)
        {
            ToDoTask toDoTask = await _context.ToDoTasks.FirstOrDefaultAsync(x => x.Id.Equals(id));

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
            ToDoTask toDoTask = _context.ToDoTasks.FirstOrDefault(x => x.Id.Equals(id));

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
