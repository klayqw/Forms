using Steam.Core.Models;

namespace Steam.Core.ViewModel;

public class BuyViewModel
{
    public Game game { get; set; }
    public IEnumerable<Game> UserGames { get; set;}
    public IEnumerable<Comment> Comments { get; set;}
}
