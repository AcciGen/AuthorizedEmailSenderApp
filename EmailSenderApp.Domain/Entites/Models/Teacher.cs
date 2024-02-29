using System.ComponentModel.DataAnnotations;

namespace EmailSenderApp.Domain.Entites.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [MaxLength(40)]
        public string Name { get; set; }
        public short Age { get; set; }

        [MaxLength(20)]
        public string Subject { get; set; }
    }
}
