using EmailSenderApp.Application.Abstractions.Repositories;
using EmailSenderApp.Domain.Entites.Models.AuthModels;
using EmailSenderApp.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace EmailSenderApp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        => _dbContext = dbContext;

        public async Task<User> InsertAsync(User user)
        {
            EntityEntry<User> entry = await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<List<User>> SelectAllAsync()
            => await _dbContext.Users.ToListAsync();

        public async Task<User> UpdateAsync(User user, string username)
        {
            var storedUser = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == username);

            if (storedUser is null)
                return null!;

            storedUser.UserName = user.UserName;
            storedUser.Login = user.Login;
            storedUser.Password = user.Password;
            storedUser.Role = user.Role;

            var entry = _dbContext.Users.Update(storedUser);
            await _dbContext.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<User> DeleteAsync(string username)
        {
            var storedUser = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == username);

            if (storedUser is null)
                return null!;

            var entry = _dbContext.Remove(storedUser);
            await _dbContext.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<User> SelectByUserNameAsync(string username)
        {
            var storedUser = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == username);

            if (storedUser is null)
                return null!;

            return storedUser!;
        }
    }
}
