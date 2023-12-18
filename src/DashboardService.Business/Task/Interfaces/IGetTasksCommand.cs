using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.Kernel.Responses;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Task.Interfaces;

public interface IGetTasksCommand
{
  Task<FindResultResponse<TaskInfo>> ExecuteAsync();
}