﻿using Steam.Core.Models;

namespace Steam.Core.ViewModel;

public class UserViewModel
{
    public User user { get; set; }
    public bool IsAnotherUser { get; set; }
    public bool IsRequested { get; set; }
    public bool IsFriend { get; set; }
    public IEnumerable<Game> games { get; set; }
    public IEnumerable<Group> groups { get; set; }
    public IEnumerable<User> Friends { get; set; } 
}