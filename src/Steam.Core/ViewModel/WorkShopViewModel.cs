using Steam.Core.Models;

namespace Steam.Core.ViewModel;

public class WorkShopViewModel
{
    public WorkShop item { get; set; }
    public IEnumerable<WorkShop> workShopUserItems { get; set; }
}
