
using ClinicVp.DataBase.DTOs;
using ClinicVp.DataBase.Models;
using ClinicVp.DataBase.Repositories;

namespace ClinicVp.DataBase.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<IEnumerable<PatientResponseDto>> GetAllPatientsAsync()
        {
            var patients = await _patientRepository.GetAllAsync();

            return patients.Select(p => new PatientResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Cpf = p.Cpf,
                Email = p.Email,
                Phone = p.Phone,
                Professional = p.Professional,
                BornDate = p.BornDate,
                Active = p.Active
            });
        }

        public async Task<PatientResponseDto?> GetPatientByIdAsync(int id)
        {
            var p = await _patientRepository.GetByIdAsync(id);
            if (p == null) return null;

            return new PatientResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Cpf = p.Cpf,
                Email = p.Email,
                Phone = p.Phone,
                Professional = p.Professional,
                BornDate = p.BornDate,
                Active = p.Active
            };
        }

        public async Task<PatientResponseDto> CreatePatientAsync(PatientCreateUpdateDto dto)
        {
            var existingPatient = await _patientRepository.GetByCpfAsync(dto.Cpf);
            if (existingPatient != null)
                throw new InvalidOperationException("Já existe um paciente cadastrado com este CPF.");

            var patient = new Patient(
                dto.Name, dto.Cpf, dto.Email, dto.Gender,
                dto.Phone, dto.Photo ?? string.Empty, dto.CivilState,
                dto.BornDate, dto.Professional, dto.BloodType,
                dto.Weight, dto.Height, dto.PhoneEmergency, dto.Notes
            );

            await _patientRepository.AddAsync(patient);

            return new PatientResponseDto
            {
                Id = patient.Id,
                Name = patient.Name,
                Cpf = patient.Cpf,
                Email = patient.Email,
                Phone = patient.Phone,
                Professional = patient.Professional,
                BornDate = patient.BornDate,
                Active = patient.Active
            };
        }

        public async Task UpdatePatientAsync(int id, PatientCreateUpdateDto dto)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            if (patient == null) throw new KeyNotFoundException("Paciente não encontrado.");

            await _patientRepository.UpdateAsync(patient);
        }

        public async Task DeletePatientAsync(int id)
        {
            await _patientRepository.DeleteAsync(id);
        }
    }
}