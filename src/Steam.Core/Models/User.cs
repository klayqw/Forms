using Microsoft.AspNetCore.Identity;
using Steam.Core.Models.ManyTable;

namespace Steam.Core.Models;

public class User : IdentityUser
{
    public string AvatarUrl { get; set; }
    public bool IsOnline {  get; set; } = false;
    public ICollection<UserGames> UserGames { get; set; }
    public ICollection<UserGroups> UserGroups { get; set; }
    public ICollection<UserWorkShopSub> UserWorkShopSub { get; set; }
    public ICollection<UserNotifications> UserNotifications { get; set; }
    public ICollection<UserFriendship> Friendships { get; set; }
    public ICollection<GroupChat> GroupChats { get; set; }

}
