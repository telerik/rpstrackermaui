using RPS.Core.Models;
using RPS.Core.Models.Dto;

namespace RPS.UI.BL;

public interface IPtItemsRepository
{
    IEnumerable<PtItem> GetAll();
    IEnumerable<PtItem> GetUserItems(int userId);
    IEnumerable<PtItem> GetOpenItems();
    IEnumerable<PtItem> GetClosedItems();
    PtItem GetItemById(int itemId);

    PtItem AddNewItem(PtNewItem newItem);
    PtItem UpdateItem(PtUpdateItem updateItem);
}