using ClinicVp.DataBase.DTOs.PatientAddress;
using ClinicVp.DataBase.Models;
using ClinicVp.DataBase.Models.Views;
using ClinicVp.DTOs.PatientDto;
using ClinicVp.DTOs.ResponsesDefault;
using ClinicVp.Repository.RPatient;

namespace ClinicVp.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IPatientAddress _addressRepository;

        public PatientService(IPatientRepository patientRepository, IPatientAddress addressRepository)
        {
            _patientRepository = patientRepository;
            _addressRepository = addressRepository;
        }

        public async Task<IEnumerable<PatientResponseDto>> GetAllPatientsAsync()
        {
            var patients = await _patientRepository.GetAllAsync();

            List<PatientResponseDto> patientsList = [];

            foreach (var item in patients)
            {
                var patient = await FormatPatient(item);
                patientsList.Add(patient);
            }

            return patientsList;
        }

        public async Task<PatientResponseDto?> GetPatientByIdAsync(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Paciente não encontrado.");

            return await FormatPatient(patient);
        }

        public async Task<Patient> GetPatientEntityIdAsync(int id)
        {
            return await _patientRepository.GetByEntityIdAsync(id) ?? throw new KeyNotFoundException("Paciente não encontrado.");
        }

        public async Task<IEnumerable<PatientResponsePreviewDto>> GetAllPatientsPreviewAsync()
        {
            return await _patientRepository.GetAllPatientPreview();
        }

        public async Task<ResponseWriteDefault> CreatePatientAsync(PatientWriteDto dto)
        {
            try
            {

                var patient = new Patient(
                    dto.Patient.Name, dto.Patient.Cpf, dto.Patient.Email, dto.Patient.Gender,
                    dto.Patient.Phone, dto.Patient.Photo ?? string.Empty, dto.Patient.CivilState,
                    dto.Patient.BornDate, dto.Patient.Professional, dto.Patient.BloodType,
                    dto.Patient.Weight, dto.Patient.Height, dto.Patient.PhoneEmergency, dto.Patient.Notes
                );

                var idPatient = await _patientRepository.AddAsync(patient);

                var address = new PatientAddress(
                    idPatient, dto.Address.UfId, dto.Address.City, dto.Address.District,
                    dto.Address.Street, dto.Address.Number, dto.Address.Cep
                );

                await _addressRepository.AddAsync(address);


                return new ResponseWriteDefault(idPatient, "Paciente criado com sucesso.");
            }
            catch
            {
                throw;
            }
        }

        public async Task<PatientResponseDto> UpdatePatientAsync(int id, PatientWriteDto dto)
        {
            try
            {
                var patient = await GetPatientEntityIdAsync(id);

                patient.Name = dto.Patient.Name;
                patient.Cpf = dto.Patient.Cpf;
                patient.Email = dto.Patient.Email;
                patient.Gender = dto.Patient.Gender;
                patient.Phone = dto.Patient.Phone;
                patient.Photo = dto.Patient.Photo ?? string.Empty;
                patient.CivilState = dto.Patient.CivilState;
                patient.BornDate = dto.Patient.BornDate;
                patient.Professional = dto.Patient.Professional;
                patient.BloodType = dto.Patient.BloodType;
                patient.Weight = dto.Patient.Weight;
                patient.Height = dto.Patient.Height;
                patient.PhoneEmergency = dto.Patient.PhoneEmergency;
                patient.Notes = dto.Patient.Notes;

                await _patientRepository.UpdateAsync(patient);

                var address = await _addressRepository.GetId(id);

                address!.Cep = dto.Address.Cep;
                address!.City = dto.Address.City;
                address!.District = dto.Address.District;
                address!.Street = dto.Address.Street;
                address!.Number = dto.Address.Number;
                address!.UfId = dto.Address.UfId;

                await _addressRepository.UpdateAsync(address);

                return await GetPatientByIdAsync(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<ResponseDeleteDefault> DeletePatientAsync(int id)
        {
            var patient = await GetPatientEntityIdAsync(id) ?? throw new KeyNotFoundException("Paciente não encontrado.");
            await _patientRepository.DeleteAsync(patient);
            return new ResponseDeleteDefault("Patient", $"Paciente de id {id} deletado com sucesso.");
        }

        public async Task<PatientResponseDto> FormatPatient(PatientData? patientData)
        {
            try
            {
                if (patientData == null) throw new KeyNotFoundException("Dados do paciente não encontrados.");

                var patient = new PatientResponseBase(
                    patientData.Id, patientData.Name, patientData.Cpf, patientData.Email,
                    patientData.Phone, patientData.Professional, patientData.BornDate, patientData.Active,
                    patientData.PhoneEmergency, patientData.Height, patientData.Weight, patientData.BloodType,
                    patientData.CivilState, patientData.Gender, patientData.Notes
                );

                var addressDto = new PatientAddressResponseDto(
                    patientData.UfAddress, patientData.City, patientData.District,
                    patientData.Street, patientData.Number, patientData.Cep
                );

                return new PatientResponseDto(patient, addressDto);
            }
            catch
            {
                throw new KeyNotFoundException("Erro ao formatar os dados do paciente.");
            }
        }
    }
}