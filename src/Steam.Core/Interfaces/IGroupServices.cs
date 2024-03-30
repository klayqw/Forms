using Microsoft.AspNetCore.Http;
using Steam.Core.Dto;
using Steam.Core.Models;
using Steam.Core.ViewModel;

namespace Steam.Core.Interfaces;

public interface IGroupServices
{
    public Task<IEnumerable<Group>> GetAll();
    public Task<Group> GetById(int id);
    public Task Add(GroupDto dto, string creator);
    public Task<IEnumerable<Group>> GetUserGroup(string creator);
    public Task JoinInGroup(int id, string userid);
    public Task<IEnumerable<Group>> ShowJoinedGroup(string id);
    public Task Leave(int id,string userid);
    public Task Delete(int id, HttpContext context);
    public Task Update(GroupDto dto,int id, HttpContext context);
    public Task<IEnumerable<User>> GetUsersInGroup(int id);
    public Task<IEnumerable<Message>> GetAllMesageFromChat(int id);
    public Task AddMessage(MessageDto message);
    public Task DeleteMessage(int id,string username);
}
