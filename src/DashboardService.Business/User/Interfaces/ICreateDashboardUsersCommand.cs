using System.Threading.Tasks;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.DashboardUser;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using System;

namespace LT.DigitalOffice.DashboardService.Business.User.Interfaces;

[AutoInject]
public interface ICreateDashboardUsersCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(CreateDashboardUsersRequest request);
}