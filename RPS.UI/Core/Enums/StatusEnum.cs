using System.ComponentModel.DataAnnotations;

namespace RPS.Core.Models.Enums;

public enum StatusEnum
{
    [Display(Name = "New")]
    New,
    [Display(Name = "Open")]
    Open,
    [Display(Name = "Closed")]
    Closed,
    [Display(Name = "Stale")]
    Stale
}