﻿using Microsoft.AspNetCore.Identity;
using Steam.Core.Interfaces;
using Steam.Core.Models;
using Steam.Infrastructure.Data;


namespace Steam.Infrastructure.Services;

public class AdminPanelService : IAdminPanel
{
    private readonly SteamDBContext steamDBContext;
    private readonly UserManager<User> userManager;
    private readonly RoleManager<IdentityRole> roleManager;
    public AdminPanelService(SteamDBContext steamDBContext, UserManager<User> user,RoleManager<IdentityRole> role) 
    {
        this.steamDBContext = steamDBContext;
        this.userManager = user;
        this.roleManager = role;
    }

    public async Task BanUserById(string id)
    {
        var user = await userManager.FindByIdAsync(id);
        if(user == null)
        {
            throw new NullReferenceException($"User not found by id {id}");
        }
        var existingRoles = await userManager.GetRolesAsync(user);
        await userManager.RemoveFromRolesAsync(user, existingRoles);
        var role = new IdentityRole { Name = "Ban" };
        await roleManager.CreateAsync(role);
        await userManager.AddToRoleAsync(user, role.Name);
    }
    public async Task UnBanUserById(string id)
    {
        var user = await userManager.FindByIdAsync(id);
        if (user == null)
        {
            throw new NullReferenceException($"User not found by id {id}");
        }
        var existingRoles = await userManager.GetRolesAsync(user);
        await userManager.RemoveFromRolesAsync(user, existingRoles);
        await userManager.AddToRoleAsync(user, "User");
    }

    public async Task<IEnumerable<User>> GetAllUser()
    {
        var users = userManager.Users.ToList();
        if(users == null)
        {
            throw new NullReferenceException("Problems with database");
        }
        var usersWithoutAdminRole = users.Where(u => !userManager.IsInRoleAsync(u, "Admin").Result).OfType<User>().ToList();
        return usersWithoutAdminRole;
    }
}
