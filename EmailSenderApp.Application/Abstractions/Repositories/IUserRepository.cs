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
        public Task<User> SelectByIdAsync(long id);
        public Task<List<User>> SelectAllAsync();
        public Task<User> UpdateAsync(User user, long id);
        public Task<User> DeleteAsync(long id);
    }
}
