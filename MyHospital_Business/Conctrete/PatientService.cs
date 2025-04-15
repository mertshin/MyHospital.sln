using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyHospital_Business.Abstraction;
using MyHospital_Core.Dtos.PatientDtos;
using MyHospital_Core.Models;
using MyHospital_Data.Context;

namespace MyHospital_Business.Conctrete
{
    public class PatientService : IPatientService
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        public PatientService(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<ApiResponse<PatientGetDto>> CreateAsync(PatientCreateDto dto)
        {
            var exists = await _db.Patients.AnyAsync(p => p.PatientId == dto.PatientId);
            if (exists)
            {
                return ApiResponse<PatientGetDto>.FailResponse("Bu TC numarasına sahip bir hasta zaten mevcut.");
            }

            var patient = _mapper.Map<Patient>(dto);
            await _db.Patients.AddAsync(patient);
            await _db.SaveChangesAsync();

            var patientDTO = _mapper.Map<PatientGetDto>(patient);
            return ApiResponse<PatientGetDto>.SuccessResponse(patientDTO, "Hasta başarıyla eklendi");
        }

        public async Task<ApiResponse<NoContent>> DeleteAsync(int id)
        {
            var patient = await _db.Patients.FirstOrDefaultAsync(p => p.PatientId == id);
            if (patient == null)
            {
                return ApiResponse<NoContent>.FailResponse("Hasta bulunamadı.");
            }
            _db.Patients.Remove(patient);
            await _db.SaveChangesAsync();

            // Başarılı yanıt döndür
            return ApiResponse<NoContent>.SuccessResponse(null, "Hasta başarıyla silindi.");
        }

        public async Task<ApiResponse<List<PatientGetDto>>> GetAllAsync()
        {
            var patients = await _db.Patients.ToListAsync();

            var dtoList = _mapper.Map<List<PatientGetDto>>(patients);

            return ApiResponse<List<PatientGetDto>>.SuccessResponse(dtoList);
        }

        public async Task<ApiResponse<PatientGetDto>> GetByIdAsync(int id)
        {
            var patient = await _db.Patients.FirstOrDefaultAsync(x => x.PatientId == id);

            if (patient == null)
                return ApiResponse<PatientGetDto>.FailResponse("Hasta bulunamadı");

            var dto = _mapper.Map<PatientGetDto>(patient);

            return ApiResponse<PatientGetDto>.SuccessResponse(dto);

        }

        public async Task<ApiResponse<NoContent>> UpdateAsync(PatientUpdateDto dto)
        {
            var patient = await _db.Patients.FirstOrDefaultAsync(p => p.PatientId == dto.PatientId);

            if (patient == null)
            {
                return ApiResponse<NoContent>.FailResponse("Hasta bulunamadı.");
            }

            _mapper.Map(dto, patient);

            await _db.SaveChangesAsync();

            return ApiResponse<NoContent>.SuccessResponse(null, "Hasta başarıyla güncellendi.");
        }
    }
}
