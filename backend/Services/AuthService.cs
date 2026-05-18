using backend.Data;
using backend.DTO;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Diagnostics;

namespace backend.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> IsEmailDuplicate(string email)
        {
            User? user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return true;
            }

            return false;
        }

        public async Task<string> CreateUser(RegisterUserDTO registerUserDTO)
        {
            User newUser = new User(registerUserDTO.Username, registerUserDTO.Password, registerUserDTO.Email);
            try
            {
                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();
            }
            catch
            {

            }

            return newUser.UserName;
        }

        public async Task<bool> Login(LoginDTO loginDTO)
        {
            User? user = await _context.Users.FindAsync(loginDTO.Username);

            if (user == null)
            {
                return false;
            }

            if (user.Password != loginDTO.Password)
            {
                return false;
            }

            return true;
        }

        public async Task<string> ChangePassword(string username, string currentPassword, string newPassword)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);

            if (user == null)
            {

            }

            if (user?.Password != currentPassword)
            {

            }

            user?.ChangePassword(newPassword);
            await _context.SaveChangesAsync();

            return username;
        }
    }
}
