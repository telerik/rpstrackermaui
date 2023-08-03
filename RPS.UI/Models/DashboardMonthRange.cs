namespace RPS.UI.Models;

public class DashboardMonthRange
{
    public string Name { get; private set; }

    public int NumberOfMonths { get; private set; }

    public DashboardMonthRange(int months) 
    {
        NumberOfMonths = months;
        switch (months)
        {
            case 3:
                Name = "3 Months";
                break;
            case 6:
                Name = "6 Months";
                break;
            case 12:
            default:
                Name = "1 Year";
                break;
        }
    }
}