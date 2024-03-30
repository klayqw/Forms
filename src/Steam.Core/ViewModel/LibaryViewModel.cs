using Steam.Core.Models;

namespace Steam.Core.ViewModel;

public class LibaryViewModel
{
    public IEnumerable<Game> games { get; set; }
    public IEnumerable<FriendsGame> friends { get; set; }
    public IEnumerable<WorkShop> works { get; set; }
}
