using RPS.Core.Models;

namespace RPS.UI.BL;

public interface IPtUserRepository
{
    IEnumerable<PtUser> GetAll();
}