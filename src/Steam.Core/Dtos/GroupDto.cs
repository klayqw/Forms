using System.ComponentModel.DataAnnotations;

namespace Steam.Core.Dto;


public class GroupDto
{
    public string GroupImageUrl { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
