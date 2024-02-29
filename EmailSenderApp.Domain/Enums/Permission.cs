using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderApp.Domain.Enums
{
    public enum Permission
    {
        CreateStudent = 1,
        GetAllStudents = 2,
        UpdateStudent = 3,
        DeleteStudent = 4,
        GetStudentByUserName = 5,
        CreateTeacher = 6,
        GetAllTeachers = 7,
        UpdateTeacher = 8,
        DeleteTeacher = 9,
        GetTeacherByUserName = 10
    }
}
