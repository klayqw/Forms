﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Steam.Core.Interfaces;
using Steam.Core.Models;
using Steam.Core.Models.ManyTable;
using Steam.Infrastructure.Data;
using System;

namespace Steam.Infrastructure.Services;

public class NotificationService : INotificationServiceBase
{
    private readonly SteamDBContext _dbContext;
    private readonly UserManager<User> userManager;
    public NotificationService(SteamDBContext dbContext, UserManager<User> userManager)
    {
        _dbContext = dbContext;
        this.userManager = userManager;
    }

    public async Task AddNotification(Notification notification)
    {
        await _dbContext.notifications.AddAsync(notification);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteNotification(int notificationid)
    {
        var todelete = await _dbContext.notifications.FindAsync(notificationid);
        _dbContext.notifications.Remove(todelete);
        await _dbContext.SaveChangesAsync();
    }
    public async Task AddNotificationToUser(string id, int notificationid)
    {
        var userNotification = new UserNotifications
        {
            UserId = id,
            NotificationId = notificationid
        };

        await _dbContext.userNotifications.AddAsync(userNotification);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Notification>> GetAllNotificationUser(string id)
    {
        var notifications = await _dbContext.userNotifications
           .Where(un => un.UserId == id)
           .Select(un => un.Notification)
           .ToArrayAsync();
        return notifications;
    }

    public async Task RemoveNotificationFromUser(string id, int notificationid)
    {
        var userNotification = await _dbContext.userNotifications
           .FirstOrDefaultAsync(un => un.UserId == id && un.NotificationId == notificationid);
        _dbContext.userNotifications.Remove(userNotification);
        await DeleteNotification(notificationid);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Notification> GetById(int id)
    {
        var notification = await _dbContext.notifications.FirstOrDefaultAsync(x => x.Id == id);
        return notification;
    }
}
