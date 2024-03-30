using Steam.Core.Models;

namespace Steam.Core.ViewModel;

public class FriendsGame
{
    public User user { get; set; }
    public IEnumerable<Game> games { get; set; }
}
