using Microsoft.AspNetCore.Mvc;
using MyHospital_Business.Abstraction;
using MyHospital_Core.Dtos.PatientDtos;
using MyHospital_Core.Models;

namespace MyHospital_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // Get all patients
        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var response = await _patientService.GetAllAsync();
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Data);
        }

        // Get patient by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var response = await _patientService.GetByIdAsync(id);
            if (!response.Success)
            {
                return NotFound(response.Message);
            }

            return Ok(response.Data);
        }

        // Create a new patient
        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody] PatientCreateDto patientCreateDto)
        {
            if (patientCreateDto == null)
            {
                return BadRequest("Geçersiz veri.");
            }

            var response = await _patientService.CreateAsync(patientCreateDto);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return CreatedAtAction(nameof(GetPatientById), new { id = response.Data.PatientId }, response.Data);
        }

        // Update an existing patient
        [HttpPut]
        public async Task<IActionResult> UpdatePatient([FromBody] PatientUpdateDto patientUpdateDto)
        {
            if (patientUpdateDto == null)
            {
                return BadRequest("Geçersiz veri.");
            }

            var response = await _patientService.UpdateAsync(patientUpdateDto);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return NoContent();
        }

        // Delete a patient
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var response = await _patientService.DeleteAsync(id);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return NoContent();
        }
    }
}
