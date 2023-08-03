using RPS.UI.ViewModels.Backlog;

namespace RPS.UI.Views.Backlog;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(DetailsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    private void Save_Clicked(object sender, EventArgs e)
    {
		(BindingContext as DetailsViewModel).SaveItem();
    }
}