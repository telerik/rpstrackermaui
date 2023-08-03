using System.Linq.Expressions;
using RPS.Core.Models;
using RPS.Core.Models.Enums;

namespace RPS.UI.BL.Helpers;

public class PtItemStatusSpecification : Specification<PtItem>
{
    private readonly StatusEnum _status;

    public PtItemStatusSpecification(StatusEnum status)
    {
        _status = status;
    }

    public override Expression<Func<PtItem, bool>> ToExpression()
    {
        return item => item.Status == _status;
    }

}