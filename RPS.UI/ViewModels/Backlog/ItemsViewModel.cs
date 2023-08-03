using CommunityToolkit.Mvvm.ComponentModel;
using RPS.Core.Models;
using RPS.Core.Models.Dto;
using System.Collections.ObjectModel;
using RPS.UI.BL;

namespace RPS.UI.ViewModels.Backlog
{
    public partial class ItemsViewModel : ObservableObject
    {
        public BacklogViewModel ParentVm { get; set; }

        [ObservableProperty]
        public ObservableCollection<PtItem> myItems;

        public ItemsViewModel(BacklogViewModel parentVm)
        {
            this.ParentVm = parentVm;
            MyItems = new ObservableCollection<PtItem>();
        }

        public void RefreshItems(ObservableCollection<PtItem> refreshedItems)
        {
            MyItems = refreshedItems;
        }

        public void InsertItem(int location, PtItem item)
        {
            MyItems.Insert(location, item);
        }

    }
}
