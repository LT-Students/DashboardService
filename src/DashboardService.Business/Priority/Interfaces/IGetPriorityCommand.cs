using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Priority.Interfaces;

[AutoInject]
public interface IGetPriorityCommand
{
  Task<OperationResultResponse<PriorityResponse>> ExecuteAsync(Guid id);
}