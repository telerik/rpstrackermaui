using RPS.Core.Models;
using RPS.Core.Models.Dto;

namespace RPS.UI.BL;

public interface IPtTasksRepository
{
    IEnumerable<PtTask> GetAllForItem(int itemId);

    PtTask AddNewTask(PtNewTask newTask);
    PtTask UpdateTask(PtUpdateTask updateTask);
    bool DeleteTask(int id, int itemId);
}