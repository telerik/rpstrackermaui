

using CommunityToolkit.Mvvm.ComponentModel;
using RPS.Core.Models;
using RPS.Core.Models.Enums;
using System.Collections.ObjectModel;

namespace RPS.UI.ViewModels.Backlog;

public partial class DetailsScreenViewModel : ObservableObject
{

    public ItemFormViewModel ItemFormVm { get; set; }

    public DetailsScreenViewModel(PtItem item)
    {
        this.ItemFormVm = new ItemFormViewModel(item);
    }

}