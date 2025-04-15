using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHospital_Core.Dtos.PatientDtos;
using MyHospital_Core.Models;

namespace MyHospital_Business.Abstraction
{
    public interface IPatientService
    {
        Task<ApiResponse<PatientGetDto>> GetByIdAsync(int id);
        Task<ApiResponse<List<PatientGetDto>>> GetAllAsync();
        Task<ApiResponse<PatientGetDto>> CreateAsync(PatientCreateDto dto);
        Task<ApiResponse<NoContent>> UpdateAsync(PatientUpdateDto dto);
        Task<ApiResponse<NoContent>> DeleteAsync(int id);
    }
}
