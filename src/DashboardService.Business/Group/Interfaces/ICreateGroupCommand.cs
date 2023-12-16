using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Group;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Group.Interfaces;

public interface ICreateGroupCommand
{
  Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateGroupRequest request);
}