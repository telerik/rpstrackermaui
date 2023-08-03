using CommunityToolkit.Maui.Views;
using RPS.UI.ViewModels.Backlog;

namespace RPS.UI.Views.Backlog.Popups;

public partial class AddItemPopup : Popup
{
	public AddItemPopup()
	{
		InitializeComponent();
	}

    private void OnSelectedItemTypeIndexChanged(object sender, EventArgs e)
    {
        string selectedItemType = ((Picker)sender).SelectedItem as string;

        var vmItemType = (BindingContext as AddItemViewModel).SelectedItemType;
    }

    private void Save_Clicked(object sender, EventArgs e)
    {
        var vm = (BindingContext as AddItemViewModel);
        var newItem = vm.GetNewItem();
        Close(newItem);
    }
}