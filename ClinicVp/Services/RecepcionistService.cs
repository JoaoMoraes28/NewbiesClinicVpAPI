using ClinicVp.ConfigurationExtensions.HashedPassword;
using ClinicVp.DataBase.Models;
using ClinicVp.DataBase.Models.Views;
using ClinicVp.DTOs.RecepcionistAddress;
using ClinicVp.DTOs.RecepcionistDto;
using ClinicVp.DTOs.ResponsesDefault;
using ClinicVp.Repository;
using System.Security.Cryptography;

namespace ClinicVp.Services
{
    public class RecepcionistService
    {

        private readonly IRecepcionist _repositoryRecepcionist;
        private readonly IRecepcoinistAddress _repositoryAddress;

        public RecepcionistService(IRecepcionist repositoryRecepcionist, IRecepcoinistAddress repositoryAddress)
        {
            _repositoryRecepcionist = repositoryRecepcionist;
            _repositoryAddress = repositoryAddress;
        }

        public async Task<List<RecepcionistResponseDto>> SelectAllRecepcionist()
        {
            var recepcionistsDatas = await _repositoryRecepcionist.GetAll();

            List<RecepcionistResponseDto> listRecepcionistResponse = [];

            foreach (var item in recepcionistsDatas)
            {
                var response = await FormatRecepcionist(item);

                listRecepcionistResponse.Add(response);

            }

            return listRecepcionistResponse;
        }

        public async Task<RecepcionistResponseDto?> SelectRecepcionistId(int id)
        {
            var recepcionist = await _repositoryRecepcionist.GetId(id) ?? throw new KeyNotFoundException();

            return await FormatRecepcionist(recepcionist);
        }

        public async Task<Recepcionist?> SelectRecepcionistEntityId(int id)
        {
            return await _repositoryRecepcionist.GetEntityId(id) ?? throw new KeyNotFoundException();
        }

        public async Task<ResponseWriteDefault> InsertRecepcionist(RecepcionistWriteDto body)
        {
            try
            {
                var password = RandomNumberGenerator.GetHexString(8);
                var passwordHashed = SecurityPassword.GetPassHashed(password);

                Recepcionist newRecepcionist = new(body.Recepcionist.Name, body.Recepcionist.Cpf,
                    body.Recepcionist.Email, body.Recepcionist.Gender, body.Recepcionist.Phone,
                    body.Recepcionist.Photo, body.Recepcionist.Salary, body.Recepcionist.Status, password);

                var recepcionist = await _repositoryRecepcionist.Add(newRecepcionist);

                RecepcionistAddress newAddress = new(recepcionist.Id, body.Address.UfId, body.Address.City,
                    body.Address.District, body.Address.Street, body.Address.Number, body.Address.Cep);

                await _repositoryAddress.Add(newAddress);

                ResponseWriteDefault response = new(recepcionist.Id, recepcionist.Email, password);

                return response;
            }
            catch
            {
                throw;
            }
        }

        public async Task<RecepcionistResponseDto> UpdateRecepcionist(RecepcionistWriteDto body, int id)
        {
            try
            {
                var verifyId = await SelectRecepcionistEntityId(id);

                Recepcionist recepcionist = new(body.Recepcionist.Name, body.Recepcionist.Cpf,
                    body.Recepcionist.Email, body.Recepcionist.Gender, body.Recepcionist.Phone,
                    body.Recepcionist.Photo, body.Recepcionist.Salary, body.Recepcionist.Status, verifyId.Password);

                var newRecepcionist = await _repositoryRecepcionist.Update(verifyId, recepcionist);

                RecepcionistAddress newAddress = new(id, body.Address.UfId, body.Address.City,
                   body.Address.District, body.Address.Street, body.Address.Number, body.Address.Cep);

                var oldAddressRecepcionist = await _repositoryAddress.Get(id);

                await _repositoryAddress.Update(oldAddressRecepcionist, newAddress);

                return await SelectRecepcionistId(id);
            }
            catch
            {
                throw;
            }

        }

        public async Task DeleteRecepcionist(int id)
        {
            var verifyId = await SelectRecepcionistEntityId(id);

            if (verifyId == null)
                throw new KeyNotFoundException();

            await _repositoryRecepcionist.Delete(verifyId);

            ResponseDeleteDefault response = new(id, "Recepcionist", $"Recepcionist de id {id} deletado.");
        }

        public async Task<RecepcionistResponseDto> FormatRecepcionist(RecepcionistData? recepcionistData)
        {
            try
            {
                var recepcionist = new RecepcionistResponseBase(recepcionistData.Id, recepcionistData.Name, recepcionistData.Salary, recepcionistData.Cpf, recepcionistData.AdmissionDate, recepcionistData.Status,
                recepcionistData.Phone, recepcionistData.Email, recepcionistData.Photo, recepcionistData.Gender);

                var address = new RecepcionistAddressResponseDto(recepcionistData.City, recepcionistData.District, recepcionistData.Street, recepcionistData.Number, recepcionistData.Cep, recepcionistData.UfAddress);

                return new RecepcionistResponseDto(recepcionist, address);
            }
            catch
            {
                throw new KeyNotFoundException();
            }

        }
    }
}
