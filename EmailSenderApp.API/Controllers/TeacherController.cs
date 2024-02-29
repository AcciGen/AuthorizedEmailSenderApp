using EmailSenderApp.API.Attributes;
using EmailSenderApp.Application.Abstractions.Repositories;
using EmailSenderApp.Domain.Entites.Models;
using EmailSenderApp.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmailSenderApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository)
            => _teacherRepository = teacherRepository;

        [HttpPost]
        [IdentityFilter(Permission.CreateTeacher)]
        public async Task<ActionResult<string>> CreateTeacherAsync(Teacher model)
        {
            Teacher teacher = new Teacher
            {
                Id = model.Id,
                Name = model.Name,
                Age = model.Age,
                Subject = model.Subject,
            };

            var result = await _teacherRepository.InsertAsync(teacher);

            return Ok(result);
        }

        [HttpGet]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> GetAllTeachersAsync()
        {
            var result = await _teacherRepository.SelectAllAsync();

            return Ok(result);
        }

        [HttpPut]
        [IdentityFilter(Permission.UpdateTeacher)]
        public async Task<IActionResult> UpdateTeacherAsync(int id, Teacher teacher)
        {
            var result = await _teacherRepository.UpdateAsync(id, teacher);

            return Ok(result);
        }

        [HttpDelete]
        [IdentityFilter(Permission.DeleteTeacher)]
        public async Task<IActionResult> DeleteTeacherAsync(int id)
        {
            var result = await _teacherRepository.DeleteAsync(id);

            return Ok(result);
        }

        [HttpGet]
        [IdentityFilter(Permission.GetTeacherById)]
        public async Task<IActionResult> GetTeacherByIdAsync(int id)
        {
            var result = await _teacherRepository.SelectByIdAsync(id);

            return Ok(result);
        }
    }
}
