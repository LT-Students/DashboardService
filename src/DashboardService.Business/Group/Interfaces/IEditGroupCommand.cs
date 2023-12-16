using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Group;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Group.Interfaces;

public interface IEditGroupCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid id, PatchGroupRequest request);
}