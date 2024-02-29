using EmailSenderApp.Domain.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderApp.Application.Abstractions.Repositories
{
    public interface ITeacherRepository
    {
        public Task<Teacher> InsertAsync(Teacher user);
        public Task<List<Teacher>> SelectAllAsync();
        public Task<Teacher> UpdateAsync(int id, Teacher teacher);
        public Task<Teacher> DeleteAsync(int id);
        public Task<Teacher> SelectByIdAsync(int id);
    }
}
