using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority.Filters;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Priority.Interfaces;

[AutoInject]
public interface IGetPrioritiesCommand
{
  Task<FindResultResponse<PriorityInfo>> ExecuteAsync(GetPrioritiesFilter filter);
}