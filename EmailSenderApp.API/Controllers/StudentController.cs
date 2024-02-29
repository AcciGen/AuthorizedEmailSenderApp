using EmailSenderApp.API.Attributes;
using EmailSenderApp.Application.Abstractions.Repositories;
using EmailSenderApp.Domain.Entites.Models;
using EmailSenderApp.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace EmailSenderApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
            => _studentRepository = studentRepository;

        [HttpPost]
        [IdentityFilter(Permission.CreateStudent)]
        public async Task<ActionResult<string>> CreateStudentAsync(Student model)
        {
            Student student = new Student
            {
                Id = model.Id,
                Name = model.Name,
                Age = model.Age,
            };

            var result = await _studentRepository.InsertAsync(student);

            return Ok(result);
        }

        [HttpGet]
        [IdentityFilter(Permission.GetAllStudents)]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            var result = await _studentRepository.SelectAllAsync();

            return Ok(result);
        }

        [HttpPut]
        [IdentityFilter(Permission.UpdateStudent)]
        public async Task<IActionResult> UpdateStudentAsync(int id, Student student)
        {
            var result = await _studentRepository.UpdateAsync(id, student);

            return Ok(result);
        }

        [HttpDelete]
        [IdentityFilter(Permission.DeleteStudent)]
        public async Task<IActionResult> DeleteStudentAsync(int id)
        {
            var result = await _studentRepository.DeleteAsync(id);

            return Ok(result);
        }

        [HttpGet]
        [IdentityFilter(Permission.GetStudentById)]
        public async Task<IActionResult> GetStudentByIdAsync(int id)
        {
            var result = await _studentRepository.SelectByIdAsync(id);

            return Ok(result);
        }
    }
}
