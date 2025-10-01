using BodyUpAPI.Dtos;

namespace BodyUpAPI.Services.Interfaces;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetAllAsync();
    Task<CategoryDto> GetAsync(int id);
}
