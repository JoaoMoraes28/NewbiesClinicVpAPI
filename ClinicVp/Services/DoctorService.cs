using ClinicVp.DataBase.DTOs;
using ClinicVp.DataBase.Models;
using ClinicVp.DataBase.Models.Enums;
using ClinicVp.DataBase.Repositories;

namespace ClinicVp.DataBase.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<IEnumerable<DoctorResponseDto>> GetAllDoctorsAsync()
        {
            var doctors = await _doctorRepository.GetAllAsync();
            
            // Mapeamento manual ou via AutoMapper para ResponseDto
            return doctors.Select(d => new DoctorResponseDto
            {
                Id = d.Id,
                Name = d.Name,
                Crm = d.Crm,
                Cpf = d.Cpf,
                Email = d.Email,
                Phone = d.Phone,
                Bio = d.Bio,
                AdmissionDate = d.AdmissionDate,
                Active = d.Status == EStatusEmployee.ACTIVATE // Exemplo de regra
            });
        }

        public async Task<DoctorResponseDto?> GetDoctorByIdAsync(int id)
        {
            var d = await _doctorRepository.GetByIdAsync(id);
            if (d == null) return null;

            return new DoctorResponseDto
            {
                Id = d.Id,
                Name = d.Name,
                Crm = d.Crm,
                Cpf = d.Cpf,
                Email = d.Email,
                Phone = d.Phone,
                Bio = d.Bio,
                AdmissionDate = d.AdmissionDate
            };
        }

        public async Task<DoctorResponseDto> CreateDoctorAsync(DoctorCreateUpdateDto dto)
        {
            // Validações de negócio (ex: verificar se CRM ou CPF já existem)
            var existingDoctor = await _doctorRepository.GetByCpfAsync(dto.Cpf);
            if (existingDoctor != null)
                throw new InvalidOperationException("Já existe um médico cadastrado com este CPF.");

            var doctor = new Doctor(
                dto.Name, dto.Cpf, dto.Email, dto.Gender,
                dto.Phone, dto.Photo ?? string.Empty, DateTime.UtcNow,
                dto.Crm, dto.CrmUfId, dto.Password, dto.Status, dto.Bio
            );

            await _doctorRepository.AddAsync(doctor);

            return new DoctorResponseDto
            {
                Id = doctor.Id,
                Name = doctor.Name,
                Crm = doctor.Crm,
                Cpf = doctor.Cpf,
                Email = doctor.Email,
                Phone = doctor.Phone,
                Bio = doctor.Bio,
                AdmissionDate = doctor.AdmissionDate
            };
        }

        public async Task UpdateDoctorAsync(int id, DoctorCreateUpdateDto dto)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);
            if (doctor == null) throw new KeyNotFoundException("Médico não encontrado.");

            // Atualiza as propriedades necessárias...
            await _doctorRepository.UpdateAsync(doctor);
        }

        public async Task DeleteDoctorAsync(int id)
        {
            await _doctorRepository.DeleteAsync(id);
        }
    }
}