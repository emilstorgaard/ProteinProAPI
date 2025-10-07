using ProteinProAPI.Dtos;

namespace ProteinProAPI.Services.Interfaces;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetAllAsync();
    Task<CategoryDto> GetAsync(int id);
}
