using System.ComponentModel.DataAnnotations;

namespace Steam.Core.Dto;

public class WorkShopDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int GameId { get; set; }
}
