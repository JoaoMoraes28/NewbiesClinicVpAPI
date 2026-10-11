using ClinicVp.DataBase.Models;
using ClinicVp.Repository;

namespace ClinicVp.Services
{
    public class UfService
    {
        private readonly IUf _repository;

        public UfService(IUf repository)
        {
            _repository = repository;
        }

        public async Task<List<Uf>> SelectAllUfs()
        {

            return await _repository.GetAll();

        }

    }
}
