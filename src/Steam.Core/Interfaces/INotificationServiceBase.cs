using Microsoft.AspNetCore.Mvc;
using Steam.Core.Models;


namespace Steam.Core.Interfaces;

public interface INotificationServiceBase
{
    public Task DeleteNotification(int notificationid);
    public Task AddNotification(Notification notification);
    public Task<IEnumerable<Notification>> GetAllNotificationUser(string id);
    public Task AddNotificationToUser(string id, int notificationid);
    public Task RemoveNotificationFromUser(string id, int notificationid);
    public Task<Notification> GetById(int id);

}
