using EmailSenderApp.Application.Abstractions.Repositories;
using EmailSenderApp.Domain.Entites.Models;
using EmailSenderApp.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EmailSenderApp.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentRepository(ApplicationDbContext dbContext)
        => _dbContext = dbContext;

        public async Task<Student> InsertAsync(Student student)
        {
            EntityEntry<Student> entry = await _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<List<Student>> SelectAllAsync()
            => await _dbContext.Students.ToListAsync();

        public async Task<Student> UpdateAsync(int id, Student student)
        {
            var storedUser = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (storedUser is null)
                return null!;

            storedUser.Id = student.Id;
            storedUser.Name = student.Name;
            storedUser.Age = student.Age;

            var entry = _dbContext.Students.Update(storedUser);
            await _dbContext.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<Student> DeleteAsync(int id)
        {
            var storedUser = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (storedUser is null)
                return null!;

            var entry = _dbContext.Remove(storedUser);
            await _dbContext.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<Student> SelectByIdAsync(int id)
        {
            var storedUser = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (storedUser is null)
                return null!;

            return storedUser!;
        }
    }
}
