using Steam.Core.Models;

namespace Steam.Core.ViewModel;

public class GroupViewModel
{
    public Group Group { get; set; }
    public IEnumerable<User> Users { get; set; }
    public IEnumerable<Group> UserGroup { get; set; }  
}
