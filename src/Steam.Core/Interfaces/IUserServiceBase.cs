using Microsoft.AspNetCore.Mvc;
using Steam.Core.Dto;
using Steam.Core.Models;


namespace Steam.Core.Interfaces;

public interface IUserServiceBase
{
    public Task<IEnumerable<Game>> GetUserGames(string id);
    public Task<IEnumerable<Group>> GetUserGroups(string id);
    public Task<IEnumerable<User>> GetAllUser();
    public Task<User> GetUser(string id);
    public Task Update(UpdateDto dto,User user);
    public Task<IEnumerable<User>> Search(string username);
    public Task UpdateUserOnlineStatus(string userid, bool status);
    public Task UpdateAvatar(string url, string id);

}
