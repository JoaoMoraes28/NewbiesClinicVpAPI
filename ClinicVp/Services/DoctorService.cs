using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicVp.DataBase.Models;
using ClinicVp.DataBase.Models.Enums;
using ClinicVp.DataBase.Models.Views;
using ClinicVp;
using ClinicVp.Repository;
using ClinicVp.DTOs.DoctorDto;

namespace ClinicVp.Services
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

            return doctors.Select(d => new DoctorResponseDto(
                new DoctorResponseBase(
                    d.Id, d.Name, d.Crm, d.CrmUfId, d.Cpf, d.Email,
                    d.Phone, d.Photo, d.Gender, d.Status, d.Bio, d.AdmissionDate
                )
            ));
        }

        public async Task<DoctorResponseDto?> GetDoctorByIdAsync(int id)
        {
            var d = await _doctorRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Médico não encontrado.");

            var responseBase = new DoctorResponseBase(
                d.Id, d.Name, d.Crm, d.CrmUfId, d.Cpf, d.Email,
                d.Phone, d.Photo, d.Gender, d.Status, d.Bio, d.AdmissionDate
            );

            return new DoctorResponseDto(responseBase);
        }

        public async Task<Doctor> GetDoctorEntityIdAsync(int id)
        {
            return await _doctorRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Médico não encontrado.");
        }

        public async Task<DoctorResponseDto> CreateDoctorAsync(DoctorWriteDto dto)
        {
            var existingDoctor = await _doctorRepository.GetByCpfAsync(dto.Doctor.Cpf);
            if (existingDoctor != null)
            {
                throw new InvalidOperationException("Já existe um médico cadastrado com este CPF.");
            }

            var doctor = new Doctor(
                dto.Doctor.Name, dto.Doctor.Cpf, dto.Doctor.Email, dto.Doctor.Gender,
                dto.Doctor.Phone, dto.Doctor.Photo ?? string.Empty,
                dto.Doctor.Crm, dto.Doctor.CrmUfId, dto.Doctor.Password, dto.Doctor.Status, dto.Doctor.Bio
            );

            var idDoctor = await _doctorRepository.AddAsync(doctor);

            return await GetDoctorByIdAsync(idDoctor);
        }

        public async Task<DoctorResponseDto> UpdateDoctorAsync(int id, DoctorWriteDto dto)
        {
            var doctor = await GetDoctorEntityIdAsync(id);

            doctor.Name = dto.Doctor.Name;
            doctor.Cpf = dto.Doctor.Cpf;
            doctor.Email = dto.Doctor.Email;
            doctor.Gender = dto.Doctor.Gender;
            doctor.Phone = dto.Doctor.Phone;
            doctor.Photo = dto.Doctor.Photo ?? string.Empty;
            doctor.Crm = dto.Doctor.Crm;
            doctor.CrmUfId = dto.Doctor.CrmUfId;
            doctor.Password = dto.Doctor.Password;
            doctor.Status = dto.Doctor.Status;
            doctor.Bio = dto.Doctor.Bio;

            await _doctorRepository.UpdateAsync(doctor);

            return await GetDoctorByIdAsync(id);
        }

        public async Task DeleteDoctorAsync(int id)
        {
            var doctor = await GetDoctorEntityIdAsync(id);

            await _doctorRepository.DeleteAsync(doctor.Id);
        }
    }
}