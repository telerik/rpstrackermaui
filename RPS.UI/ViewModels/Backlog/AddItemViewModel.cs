using CommunityToolkit.Mvvm.ComponentModel;
using RPS.Core.Models.Dto;
using RPS.Core.Models.Enums;
using System.Collections.ObjectModel;

namespace RPS.UI.ViewModels.Backlog;

public partial class AddItemViewModel : ObservableObject
{
    public string Title { get; set; }
    public string Description { get; set; }

    public string SelectedItemType { get; set; }

    public ItemTypeEnum SelectedItemTypeEnum
    {
        get
        {
            if (SelectedItemType != null)
            {
                return Enum.Parse<ItemTypeEnum>(SelectedItemType);
            }
            else
            {
                return ItemTypeEnum.PBI;
            }
        }
    }

    private ObservableCollection<string> iTypes;

    public ObservableCollection<string> ItemTypes
    {
        get
        {
            if (iTypes == null)
            {
                var itemTypeEnumArray = Enum.GetValues<ItemTypeEnum>();
                iTypes = new ObservableCollection<string>(itemTypeEnumArray.Select(e => e.ToString()));
            }

            return iTypes;
        }
        set
        {
            iTypes = value;
        }
    }

    public PtNewItem GetNewItem()
    {
        var newItem = new PtNewItem();

        newItem.Title = Title;
        newItem.Description = Description;
        newItem.TypeStr = SelectedItemTypeEnum;

        return newItem;
    }
}