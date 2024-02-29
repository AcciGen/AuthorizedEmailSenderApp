using EmailSenderApp.Application.Abstractions.Repositories;
using EmailSenderApp.Domain.Entites.Models;
using EmailSenderApp.Domain.Entites.Models.AuthModels;
using EmailSenderApp.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderApp.Infrastructure.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TeacherRepository(ApplicationDbContext dbContext)
        => _dbContext = dbContext;

        public async Task<Teacher> InsertAsync(Teacher teacher)
        {
            EntityEntry<Teacher> entry = await _dbContext.Teachers.AddAsync(teacher);
            await _dbContext.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<List<Teacher>> SelectAllAsync()
            => await _dbContext.Teachers.ToListAsync();

        public async Task<Teacher> UpdateAsync(int id, Teacher teacher)
        {
            var storedUser = await _dbContext.Teachers.FirstOrDefaultAsync(x => x.Id == id);

            if (storedUser is null)
                return null!;

            storedUser.Id = teacher.Id;
            storedUser.Name = teacher.Name;
            storedUser.Age = teacher.Age;
            storedUser.Subject = teacher.Subject;

            var entry = _dbContext.Teachers.Update(storedUser);
            await _dbContext.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<Teacher> DeleteAsync(int id)
        {
            var storedUser = await _dbContext.Teachers.FirstOrDefaultAsync(x => x.Id == id);

            if (storedUser is null)
                return null!;

            var entry = _dbContext.Remove(storedUser);
            await _dbContext.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<Teacher> SelectByIdAsync(int id)
        {
            var storedUser = await _dbContext.Teachers.FirstOrDefaultAsync(x => x.Id == id);

            if (storedUser is null)
                return null!;

            return storedUser!;
        }
    }
}
