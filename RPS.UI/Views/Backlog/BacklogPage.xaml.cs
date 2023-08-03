using CommunityToolkit.Maui.Views;
using RPS.Core.Models;
using RPS.Core.Models.Dto;
using RPS.UI.ViewModels.Backlog;
using RPS.UI.Views.Backlog.Popups;

namespace RPS.UI.Views.Backlog;

public partial class BacklogPage : ContentPage
{
	public BacklogPage(BacklogViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}

    public async void AddItem_Clicked(object sender, EventArgs e)
    {
        var addNewItemPopup = new AddItemPopup();
        var result = await this.ShowPopupAsync(addNewItemPopup) as PtNewItem;

        if (result != null)
        {
            (BindingContext as BacklogViewModel).SaveNewItem(result);
        }
    }

    public void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // string previous = (e.PreviousSelection.FirstOrDefault() as PtItem);
        var selItem = (e.CurrentSelection.FirstOrDefault() as PtItem);
        if (selItem != null)
        {
            var vm = BindingContext as BacklogViewModel;
            var vmDetails = new DetailsViewModel(selItem, vm.itemsRepo, vm.tasksRepo);
            Navigation.PushAsync(new DetailsPage(vmDetails));
        }

        ((CollectionView)sender).SelectedItem = null;
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        var vm = BindingContext as BacklogViewModel;
        vm.GetRefreshedItems();
    }
}