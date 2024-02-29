using EmailSenderApp.Domain.Entites.Models;

namespace EmailSenderApp.Application.Abstractions.Repositories
{
    public interface IStudentRepository
    {
        public Task<Student> InsertAsync(Student student);
        public Task<List<Student>> SelectAllAsync();
        public Task<Student> UpdateAsync(int id, Student student);
        public Task<Student> DeleteAsync(int id);
        public Task<Student> SelectByIdAsync(int id);
    }
}
