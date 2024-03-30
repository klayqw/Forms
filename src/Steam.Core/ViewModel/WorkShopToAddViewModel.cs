using Steam.Core.Dto;
using Steam.Core.Models;

namespace Steam.Core.ViewModel;
public class WorkShopToAddViewModel
{
    public WorkShopDto WorkShopDto { get; set; }
    public IEnumerable<Game> Games { get; set; }
}
