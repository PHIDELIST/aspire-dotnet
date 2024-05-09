using Models;
namespace api.Services.DelphITService;
public interface IDelphITService
{
    Task<DelphIT?> GetByIdAsync(int id);
    Task<IEnumerable<DelphIT>> GetAllAsync();
    Task AddAsync(DelphIT newItem);
}