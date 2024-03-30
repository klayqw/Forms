
using Steam.Core.Models;

namespace Steam.Core.Interfaces;

public interface IAdminPanel
{
    public Task<IEnumerable<User>> GetAllUser();
    public Task BanUserById(string id);
    public Task UnBanUserById(string id);
}
