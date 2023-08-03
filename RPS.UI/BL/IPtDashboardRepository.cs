using RPS.Core.Models.Dto;

namespace RPS.UI.BL;

public interface IPtDashboardRepository
{
    PtDashboardStatusCounts GetStatusCounts(PtDashboardFilter filter);
    PtDashboardFilteredIssues GetFilteredIssues(PtDashboardFilter filter);
}