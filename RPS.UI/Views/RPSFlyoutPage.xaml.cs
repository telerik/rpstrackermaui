using RPS.UI.Models;

namespace RPS.UI.Views;

public partial class RPSFlyoutPage : FlyoutPage
{
	public RPSFlyoutPage()
	{
		InitializeComponent();
        flyoutPage.collectionView.SelectionChanged += OnSelectionChanged;
    }

    void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = e.CurrentSelection.FirstOrDefault() as FlyoutMenuItem;
        if (item != null)
        {
            var vm = Handler.MauiContext.Services.GetService(item.TargetVmType);
            //var vm = this.Handler.MauiContext.Services.GetServices<TopLevelPage2ViewModel>().FirstOrDefault();
            var newPage = (Page)Activator.CreateInstance(item.TargetPageType, vm);

            //Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
            Detail = new NavigationPage(newPage);
            if (!((IFlyoutPageController)this).ShouldShowSplitMode)
                IsPresented = false;
        }
    }
}