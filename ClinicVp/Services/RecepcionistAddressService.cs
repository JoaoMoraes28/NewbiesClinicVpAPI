using ClinicVp.DataBase.Models;
using ClinicVp.Repository.RRecepcionist;

namespace ClinicVp.Services
{
    public class RecepcionistAddressService
    {

        private readonly IRecepcoinistAddress _repository;

        public RecepcionistAddressService(IRecepcoinistAddress repository)
        {
            _repository = repository;
        }

        public async Task<RecepcionistAddress?> SelectRecepcionistAddressId(int id)
        {
            return await _repository.Get(id);
        }

        public async Task InserRecepcionistAddress(RecepcionistAddress address)
        {
            await _repository.Add(address);
        }

        public async Task UpdateRecepcionistAddress(RecepcionistAddress address, RecepcionistAddress newAddress)
        {
            await _repository.Update(address, newAddress);
        }

    }
}
