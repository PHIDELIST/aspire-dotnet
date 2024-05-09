using Models;
namespace api.Services.DelphITService;
public interface IDelphITService
{
    Task<IEnumerable<DelphIT>> GetAllAsync();
    Task AddAsync(DelphIT newItem);
}