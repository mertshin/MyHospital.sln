using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHospital_Core.Dtos.PatientDtos
{
    public class PatientCreateDto
    {
        [Required]
        [StringLength(11, MinimumLength = 11)]
        public int PatientId { get; set; } // TCKN gibi

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
