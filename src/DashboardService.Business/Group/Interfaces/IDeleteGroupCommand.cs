using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Group.Interfaces;

public interface IDeleteGroupCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid id);
}