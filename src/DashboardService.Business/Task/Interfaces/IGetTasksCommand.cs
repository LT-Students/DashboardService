using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task.Filters;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Task.Interfaces;

[AutoInject]
public interface IGetTasksCommand
{
  Task<FindResultResponse<TaskInfo>> ExecuteAsync(GetTasksFilter filter);
}