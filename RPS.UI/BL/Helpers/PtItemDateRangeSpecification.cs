using System.Linq.Expressions;
using RPS.Core.Models;

namespace RPS.UI.BL.Helpers;

public class PtItemDateRangeSpecification : Specification<PtItem>
{
    private readonly DateTime _start;
    private readonly DateTime _end;

    public PtItemDateRangeSpecification(DateTime start, DateTime end)
    {
        _start = start;
        _end = end;
    }

    public override Expression<Func<PtItem, bool>> ToExpression()
    {
        return item => item.DateCreated >= _start && item.DateCreated <= _end;
    }

}