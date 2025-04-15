using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHospital_Core.Dtos.PatientDtos
{
    public class PatientGetDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Age => DateTime.Now.Year - DateOfBirth.Year;
        public DateTime DateOfBirth { get; set; }
        public string BloodType { get; set; }
    }
}
