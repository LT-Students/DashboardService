using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Group;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Group.Interfaces;

[AutoInject]
public interface IEditGroupCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid id, JsonPatchDocument<EditGroupRequest> request);
}