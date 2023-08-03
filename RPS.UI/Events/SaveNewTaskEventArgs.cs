using RPS.Core.Models.Dto;

namespace RPS.UI.Events;

public delegate void SaveNewTaskEventHandler(object sender, SaveNewTaskEventArgs e);

public class SaveNewTaskEventArgs : EventArgs
{
    public SaveNewTaskEventArgs(PtNewTask newTask)
    {
        this.NewTask = newTask;
    }

    public PtNewTask NewTask { get; set; }
}