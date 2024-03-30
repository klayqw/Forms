using System.ComponentModel.DataAnnotations;

namespace Steam.Core.Models;

public class Notification
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string UserTo { get; set; }
    [Required]
    public string UserFrom { get; set; }
    [Required]
    public string Type {  get; set; }

}
