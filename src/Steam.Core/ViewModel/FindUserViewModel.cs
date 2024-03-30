using Steam.Core.Models;

namespace Steam.Core.ViewModel;

public class FindUserViewModel
{
    public IEnumerable<User> users { get; set; }
    public User currentUser { get; set; }
}
