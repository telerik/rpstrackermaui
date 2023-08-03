using RPS.Core.Models;

namespace RPS.UI.Events;

public delegate void DeleteTaskEventHandler(object sender, DeleteTaskEventArgs e);

public class DeleteTaskEventArgs : EventArgs
{
    public DeleteTaskEventArgs(PtTask task)
    {
        this.Task = task;
    }
    public PtTask Task { get; set; }
}