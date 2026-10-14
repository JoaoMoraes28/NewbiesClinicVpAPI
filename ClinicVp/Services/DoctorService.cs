using ClinicVp.ConfigurationExtensions.HashedPassword;
using ClinicVp.DataBase.Models;
using ClinicVp.DataBase.Models.Views;
using ClinicVp.DTOs.DoctorAddress;
using ClinicVp.DTOs.DoctorDto;
using ClinicVp.DTOs.ResponsesDefault;
using ClinicVp.Repository.RDoctor;
using System.Security.Cryptography;

namespace ClinicVp.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IDoctorAddress _addressRepository;

        public DoctorService(IDoctorRepository doctorRepository, IDoctorAddress addressRepository)
        {
            _doctorRepository = doctorRepository;
            _addressRepository = addressRepository;
        }

        public async Task<IEnumerable<DoctorResponseDto>> GetAllDoctorsAsync()
        {
            var doctors = await _doctorRepository.GetAllAsync();

            List<DoctorResponseDto> doctorsList = [];

            foreach (var item in doctors)
            {
                var doctor = await FormatDoctor(item);

                doctorsList.Add(doctor);
            }

            return doctorsList;
        }

        public async Task<DoctorResponseDto?> GetDoctorByIdAsync(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Médico não encontrado.");

            return await FormatDoctor(doctor);
        }

        public async Task<Doctor> GetDoctorEntityIdAsync(int id)
        {
            return await _doctorRepository.GetByEntityIdAsync(id) ?? throw new KeyNotFoundException("Médico não encontrado.");
        }

        public async Task<ResponseWriteEmployee> CreateDoctorAsync(DoctorWriteDto dto)
        {
            try
            {
                var existingDoctor = await _doctorRepository.GetByCpfAsync(dto.Doctor.Cpf);
                if (existingDoctor != null)
                {
                    throw new InvalidOperationException("Já existe um médico cadastrado com este CPF.");
                }

                var password = RandomNumberGenerator.GetHexString(8);
                var hashedPassword = SecurityPassword.GetPassHashed(password);

                var doctor = new Doctor(
                    dto.Doctor.Name, dto.Doctor.Cpf, dto.Doctor.Email, dto.Doctor.Gender,
                    dto.Doctor.Phone, dto.Doctor.Photo ?? string.Empty,
                    dto.Doctor.Crm, dto.Doctor.CrmUfId, hashedPassword, dto.Doctor.Status, dto.Doctor.Bio
                );

                var idDoctor = await _doctorRepository.AddAsync(doctor);

                var address = new DoctorAddress(idDoctor, dto.Address.UfId, dto.Address.City, dto.Address.District,
                    dto.Address.Street, dto.Address.Number, dto.Address.Cep);

                await _addressRepository.AddAsync(address);

                var response = new ResponseWriteEmployee(idDoctor, dto.Doctor.Email, password);

                return response;
            }
            catch
            {
                throw;
            }
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
            doctor.Status = dto.Doctor.Status;
            doctor.Bio = dto.Doctor.Bio;

            await _doctorRepository.UpdateAsync(doctor);

            return await GetDoctorByIdAsync(id);
        }

        public async Task<ResponseDeleteDefault> DeleteDoctorAsync(int id)
        {
            var doctor = await GetDoctorEntityIdAsync(id);

            await _doctorRepository.DeleteAsync(doctor);

            return new ResponseDeleteDefault("Doctor", $"Doutor de id {id} deletado com sucesso.");
        }

        public async Task<DoctorResponseDto> FormatDoctor(DoctorData? doctorData)
        {
            try
            {

                var doctor = new DoctorResponseBase(doctorData.Id, doctorData.Name, doctorData.Crm, doctorData.UfCrm,
                    doctorData.Cpf, doctorData.Email, doctorData.Phone, doctorData.Photo, doctorData.Gender,
                    doctorData.Status, doctorData.Bio, doctorData.AdmissionDate, doctorData.Contract);

                var address = new DoctorAddressResponseDto(doctorData.UfAddress, doctorData.City, doctorData.District,
                    doctorData.Street, doctorData.Number, doctorData.Cep);

                return new DoctorResponseDto(doctor, address);

            }
            catch
            {
                throw new KeyNotFoundException();
            }
        }
    }
}