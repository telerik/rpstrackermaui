using CommunityToolkit.Mvvm.ComponentModel;
using RPS.Core.Models;
using RPS.Core.Models.Dto;
using RPS.UI.Events;
using System.Collections.ObjectModel;


namespace RPS.UI.ViewModels.Backlog;

public partial class TasksScreenViewModel : ObservableObject
{

    [ObservableProperty]
    public string taskName;

    [ObservableProperty]
    public ObservableCollection<PtTask> tasks;

    [ObservableProperty]
    public PtTask selectedTask;

    private PtItem TheItem { get; set; }

    public event DeleteTaskEventHandler DeleteTaskEvent;
    public event SaveNewTaskEventHandler SaveNewTaskEvent;

    public TasksScreenViewModel(PtItem item) 
    {
        TheItem = item;
        Tasks = new ObservableCollection<PtTask>(item.Tasks.Where(t=>t.DateDeleted == null));
    }

    public void DeleteSelectedTask()
    {
        DeleteTaskEventArgs args = new DeleteTaskEventArgs(SelectedTask);
        DeleteTaskEvent(this, args);
    }


    public void SaveNewTask()
    {
        PtNewTask newTask = new PtNewTask
        {
            ItemId = TheItem.Id,
            Title = TaskName
        };

        SaveNewTaskEventArgs args = new SaveNewTaskEventArgs(newTask);
        SaveNewTaskEvent(this, args);

        TaskName = string.Empty;
    }

}