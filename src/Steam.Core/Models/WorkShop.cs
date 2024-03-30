
using System.ComponentModel.DataAnnotations;

namespace Steam.Core.Models;

public class WorkShop
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public int Like {  get; set; }
    [Required]
    public int Dislike {  get; set; }
    [Required]
    public int Subscribers { get; set; }
    [Required]
    public string Creator {  get; set; }    
    public int GameId { get; set; }
    public Game Game { get; set; }
}
