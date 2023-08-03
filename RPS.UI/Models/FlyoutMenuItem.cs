namespace RPS.UI.Models;

public  class FlyoutMenuItem
{
    public string Title { get; set; }
    public string IconSource { get; set; }
    public Type TargetPageType { get; set; }
    public Type TargetVmType { get; set; }
}