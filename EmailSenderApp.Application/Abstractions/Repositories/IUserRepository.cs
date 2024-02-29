using EmailSenderApp.Domain.Entites.Models.AuthModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderApp.Application.Abstractions.Repositories
{
    public interface IUserRepository
    {
        public Task<User> InsertAsync(User user);
        public Task<List<User>> SelectAllAsync();
        public Task<User> UpdateAsync(User user, string username);
        public Task<User> DeleteAsync(string username);
        public Task<User> SelectByUserNameAsync(string username);
    }
}
