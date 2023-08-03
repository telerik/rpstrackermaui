using System.Linq.Expressions;
using RPS.Core.Models;

namespace RPS.UI.BL.Helpers;

public class PtItemUserIdSpecification : Specification<PtItem>
{
    private readonly int _userId;

    public PtItemUserIdSpecification(int userId)
    {
        _userId = userId;
    }

    public override Expression<Func<PtItem, bool>> ToExpression()
    {
        if (_userId == 0)
        {
            return item => true;
        }
        else
        {
            return item => item.Assignee.Id == _userId;
        }
    }

}