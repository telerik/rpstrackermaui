using CommunityToolkit.Mvvm.ComponentModel;
using RPS.Core.Models;
using RPS.Core.Models.Dto;
using System.Collections.ObjectModel;
using RPS.UI.BL;

namespace RPS.UI.ViewModels.Backlog;

public partial class BacklogViewModel : ObservableObject
{

    private readonly int CURRENT_USER_ID = 21;
    public readonly IPtItemsRepository itemsRepo;
    public readonly IPtTasksRepository tasksRepo;

    public ItemsViewModel ItemsVm { get; private set; }

    public BacklogViewModel(IPtItemsRepository itemsRepo, IPtTasksRepository tasksRepo)
    {
        this.itemsRepo = itemsRepo;
        this.tasksRepo = tasksRepo;

        this.ItemsVm = new ItemsViewModel(this);
    }

    public ObservableCollection<PtItem> GetRefreshedItems()
    {
        var refreshedItems = new ObservableCollection<PtItem>(itemsRepo.GetAll());
        ItemsVm.RefreshItems(refreshedItems);
        return refreshedItems;
    }

    public void SaveNewItem(PtNewItem newItem)
    {
        newItem.UserId = CURRENT_USER_ID;
        var savedItem = itemsRepo.AddNewItem(newItem);
        ItemsVm.InsertItem(0, savedItem);
    }
}