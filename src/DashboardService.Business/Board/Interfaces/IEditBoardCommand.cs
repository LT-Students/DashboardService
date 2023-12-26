using LT.DigitalOffice.Kernel.Responses;
using System.Threading.Tasks;
using System;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board;
using LT.DigitalOffice.Kernel.Attributes;
using Microsoft.AspNetCore.JsonPatch;

namespace LT.DigitalOffice.DashboardService.Business.Board.Interfaces;

[AutoInject]
public interface IEditBoardCommand
{
  public Task<OperationResultResponse<bool>> ExecuteAsync(Guid id, JsonPatchDocument<PatchBoardRequest> request);
}
