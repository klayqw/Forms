﻿namespace Steam.Models;

public class UserFriendship
{
    public int Id { get; set; } 
    public string UserId { get; set; }
    public User User { get; set; }

    public string FriendId { get; set; }
    public User Friend { get; set; }
}