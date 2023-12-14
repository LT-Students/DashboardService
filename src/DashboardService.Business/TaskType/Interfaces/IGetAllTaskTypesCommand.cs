using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.Kernel.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.TaskType.Interfaces;

public interface IGetAllTaskTypesCommand
{
  Task<FindResultResponse<IEnumerable<TaskTypeInfo>>> ExecuteAsync();
}