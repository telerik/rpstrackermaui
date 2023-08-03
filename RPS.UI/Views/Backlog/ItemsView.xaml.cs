using RPS.Core.Models;
using RPS.UI.ViewModels.Backlog;

namespace RPS.UI.Views.Backlog;

public partial class ItemsView : ContentView
{
	public ItemsView()
	{
		InitializeComponent();
	}

    public void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // string previous = (e.PreviousSelection.FirstOrDefault() as PtItem);
        var selItem = (e.CurrentSelection.FirstOrDefault() as PtItem);
        if (selItem != null)
        {
            NavigateToDetails(selItem);
        }

        ((CollectionView)sender).SelectedItem = null;
    }

    private void NavigateToDetails(PtItem selItem)
    {
        var vm = BindingContext as ItemsViewModel;
        var vmDetails = new DetailsViewModel(selItem as PtItem, vm.ParentVm.itemsRepo, vm.ParentVm.tasksRepo);
        Navigation.PushAsync(new DetailsPage(vmDetails));
    }


}