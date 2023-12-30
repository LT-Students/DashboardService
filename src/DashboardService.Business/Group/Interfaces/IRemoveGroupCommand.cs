using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Group.Interfaces;

[AutoInject]
public interface IRemoveGroupCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid id);
}