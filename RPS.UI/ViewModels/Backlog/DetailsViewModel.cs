using CommunityToolkit.Mvvm.ComponentModel;
using RPS.Core.Models;
using RPS.Core.Models.Dto;
using RPS.UI.Events;
using System.Collections.ObjectModel;
using RPS.UI.BL;


namespace RPS.UI.ViewModels.Backlog;

public partial class DetailsViewModel : ObservableObject
{
    private readonly IPtItemsRepository itemsRepo;
    private readonly IPtTasksRepository tasksRepo;

    public PtItem TheItem { get; set; }

    [ObservableProperty]
    public string title;

    [ObservableProperty]
    public object selection = "Details";

    [ObservableProperty]
    private bool tab1Visible;

    [ObservableProperty]
    private bool tab2Visible;

    partial void OnSelectionChanged(object value)
    {
        var valStr = value as string;
        if (valStr == "Details")
        {
            Tab1Visible = true;
            Tab2Visible = false;
        }
        else if (valStr == "Tasks")
        {
            Tab1Visible = false;
            Tab2Visible = true;
        }
    }

    public DetailsScreenViewModel DetailsScreenVm { get; set; }
    public TasksScreenViewModel TasksScreenVm { get; set; }

    public DetailsViewModel(PtItem item, IPtItemsRepository iPtRepo, IPtTasksRepository tPtRepo)
    {
        this.itemsRepo = iPtRepo;
        this.tasksRepo = tPtRepo;

        TheItem = item;
        title = item.Title;
        Tab1Visible = selection.ToString().Equals("Details");
        tab2Visible = selection.ToString().Equals("Tasks");

        DetailsScreenVm = new DetailsScreenViewModel(item);
        TasksScreenVm = new TasksScreenViewModel(item);

        TasksScreenVm.DeleteTaskEvent += new DeleteTaskEventHandler(DeleteTask);
        TasksScreenVm.SaveNewTaskEvent += new SaveNewTaskEventHandler(SaveNewTask);
    }

    public void DeleteTask(object sender, DeleteTaskEventArgs e)
    {
        var result = tasksRepo.DeleteTask(e.Task.Id, TheItem.Id);
        if (result)
        {
            var currentTasks = tasksRepo.GetAllForItem(TheItem.Id);
            TheItem.Tasks = currentTasks.ToList();
            TasksScreenVm.Tasks = new ObservableCollection<PtTask>(TheItem.Tasks);
        }
    }

    public void SaveNewTask(object sender, SaveNewTaskEventArgs e)
    {
        var newTask = tasksRepo.AddNewTask(e.NewTask);
        if (newTask != null)
        {
            var currentTasks = tasksRepo.GetAllForItem(TheItem.Id);
            TheItem.Tasks = currentTasks.ToList();
            TasksScreenVm.Tasks = new ObservableCollection<PtTask>(TheItem.Tasks);
        }
    }

    public void SaveItem()
    {
        Title = DetailsScreenVm.ItemFormVm.Title;

        var updateItem = new PtUpdateItem
        {
            Id = TheItem.Id,
            Title = DetailsScreenVm.ItemFormVm.Title,
            Description = DetailsScreenVm.ItemFormVm.Description,
            Type = DetailsScreenVm.ItemFormVm.SelectedItemTypeEnum,
            AssigneeId = TheItem.Assignee.Id,
            Estimate = Convert.ToInt32(DetailsScreenVm.ItemFormVm.Estimate),
            Priority = DetailsScreenVm.ItemFormVm.SelectedPriorityEnum,    
            Status = DetailsScreenVm.ItemFormVm.SelectedStatusEnum
        };

        var updatedItem = itemsRepo.UpdateItem(updateItem);
    }
}