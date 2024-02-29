using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
