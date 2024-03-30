﻿using Steam.Core.Models.ManyTable;
using System.ComponentModel.DataAnnotations;

namespace Steam.Core.Models;

public class Group
{
    public int Id { get; set; }
    [Required]
    public string GroupImageUrl { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public int MemberCount { get; set; }
    [Required]
    public string Creator { get; set; }
   
    public ICollection<UserGroups> UserGroups { get; set; }
    public ICollection<GroupChat> GroupChats { get; set; }
}