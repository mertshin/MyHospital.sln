using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHospital_Core.Dtos.PatientDtos
{
    public class PatientUpdateDto : PatientCreateDto
    {
        public int Id { get; set; }
    }
}
