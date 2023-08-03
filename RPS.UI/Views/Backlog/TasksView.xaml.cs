using RPS.UI.ViewModels.Backlog;

namespace RPS.UI.Views.Backlog;

public partial class TasksView : ContentView
{

    public string BooPage { get; set; }

	public TasksView()
	{
		InitializeComponent();
	}

    public async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var curApp = App.Current;
        var mp = curApp.MainPage;
        string action = await mp.DisplayActionSheet("Task Action", "Cancel", "null", "Delete", "Complete");

        var vm = (TasksScreenViewModel)BindingContext;

        if (action.Equals("Delete"))
        {
            vm.DeleteSelectedTask();
        }
    }

    private void SaveTaskButton_Clicked(object sender, EventArgs e)
    {
        var vm = (TasksScreenViewModel)BindingContext;
        vm.SaveNewTask();

    }
}