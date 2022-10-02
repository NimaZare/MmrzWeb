using Microsoft.EntityFrameworkCore;
using MmrzWeb.Data;

namespace MmrzWeb.Authentication
{
    public class UserAccountService
    {
        protected readonly AppDbContext _context;

        public UserAccountService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserAccount>?> GetUsersAsync()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<UserAccount?> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
                if (user is not null)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> AddUserAsync(UserAccount user)
        {
            try
            {
                var users = await _context.Users.ToListAsync();
                if (users is null || users.Count == 0)
                {
                    await _context.Users.AddAsync(user);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateUser(UserAccount user)
        {
            try
            {
                var userToEdit = _context.Users.FirstOrDefault(u => u.UserId == user.UserId);
                if (userToEdit is not null)
                {
                    _context.Entry(user).State = EntityState.Modified;
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteUser(UserAccount user)
        {
            try
            {
                var userToDelete = _context.Users.FirstOrDefault(u => u.UserId == user.UserId);
                if (userToDelete is not null)
                {
                    _context.Entry(user).State = EntityState.Deleted;
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
