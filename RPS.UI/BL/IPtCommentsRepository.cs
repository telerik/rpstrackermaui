using RPS.Core.Models;
using RPS.Core.Models.Dto;

namespace RPS.UI.BL;

public interface IPtCommentsRepository
{
    IEnumerable<PtComment> GetAllForItem(int itemId);
    PtComment AddNewComment(PtNewComment newComment);
}