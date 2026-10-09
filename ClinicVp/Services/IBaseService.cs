namespace ClinicVp.DataBase.Services
{
    public interface IBaseService<TCreateDto, TResponseDto> where TCreateDto : class where TResponseDto : class
    {
        Task<IEnumerable<TResponseDto>> GetAllAsync();
        Task<TResponseDto?> GetByIdAsync(int id);
        Task<TResponseDto> AddAsync(TCreateDto dto);
        Task UpdateAsync(int id, TCreateDto dto);
        Task DeleteAsync(int id);
    }
}