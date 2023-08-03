using CommunityToolkit.Mvvm.ComponentModel;
using RPS.Core.Models.Enums;
using RPS.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace RPS.UI.ViewModels.Backlog;

public class ItemFormViewModel : ObservableObject
{

    private string title;
    private string description;

    private ItemTypeEnum itemType;
    private PriorityEnum priority;
    private StatusEnum status;

    private int estimate;


    public List<string> ItemTypes
    {
        get
        {
            var arr = Enum.GetValues<ItemTypeEnum>();
            var vals = new List<string>(arr.Select(e => e.ToString()));
            return vals;
        }
    }

    public List<string> Priorities
    {
        get
        {
            var arr = Enum.GetValues<PriorityEnum>();
            var vals = new List<string>(arr.Select(e => e.ToString()));
            return vals;
        }
    }

    public List<string> Statuses
    {
        get
        {
            var arr = Enum.GetValues<StatusEnum>();
            var vals = new List<string>(arr.Select(e => e.ToString()));
            return vals;
        }
    }

    public ItemFormViewModel(PtItem item)
    {
        if (item != null)
        {
            this.Title = item.Title;
            this.Description = item.Description;
            this.ItemType = item.Type;
            this.SelectedItemType = item.Type.ToString();
            this.Priority = item.Priority;
            this.SelectedPriority = item.Priority.ToString();
            this.Status = item.Status;
            this.SelectedStatus = item.Status.ToString();
            this.Estimate = item.Estimate;
        }
        else
        {
            this.Estimate = 1;
        }

    }

    [Required]
    [Display(Name = "Title", Prompt = "Enter Title")]
    public string Title
    {
        get => this.title;
        set => this.SetProperty(ref this.title, value);
    }

    [Required]
    [Display(Name = "Description", Prompt = "Enter Description")]
    public string Description
    {
        get => this.description;
        set => this.SetProperty(ref this.description, value);
    }

    [Range(1, 20)]
    [Display(Name = "Estimate")]
    public int Estimate
    {
        get => this.estimate;
        set => this.SetProperty(ref this.estimate, value);
    }

    [Display(Name = "Type")]
    public ItemTypeEnum ItemType
    {
        get => this.itemType;
        set => this.SetProperty(ref this.itemType, value);
    }

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

    [Display(Name = "Priority")]
    public PriorityEnum Priority
    {
        get => this.priority;
        set => this.SetProperty(ref this.priority, value);
    }
    public string SelectedPriority { get; set; }
    public PriorityEnum SelectedPriorityEnum
    {
        get
        {
            if (SelectedPriority != null)
            {
                return Enum.Parse<PriorityEnum>(SelectedPriority);
            }
            else
            {
                return PriorityEnum.Medium;
            }
        }
    }



    [Display(Name = "Status")]
    public StatusEnum Status
    {
        get => this.status;
        set => this.NotifyUpdateValue(ref this.status, value);
    }
    public string SelectedStatus { get; set; }
    public StatusEnum SelectedStatusEnum
    {
        get
        {
            if (SelectedStatus != null)
            {
                return Enum.Parse<StatusEnum>(SelectedStatus);
            }
            else
            {
                return StatusEnum.Open;
            }
        }
    }


    private bool NotifyUpdateValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        return this.SetProperty(ref field, value);
    }

}

