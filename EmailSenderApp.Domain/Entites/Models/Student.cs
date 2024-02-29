using System.ComponentModel.DataAnnotations;

namespace EmailSenderApp.Domain.Entites.Models
{
    public class Student
    {
        public int Id { get; set; }

        [MaxLength(40)]
        public string Name { get; set; }
        public short Age { get; set; }
    }
}
