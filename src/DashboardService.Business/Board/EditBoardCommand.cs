using LT.DigitalOffice.DashboardService.Business.Board.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board;
using LT.DigitalOffice.Kernel.Responses;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.JsonPatch;

namespace LT.DigitalOffice.DashboardService.Business.Board;

public class EditBoardCommand : IEditBoardCommand
{
  public Task<OperationResultResponse<bool>> ExecuteAsync(Guid id, JsonPatchDocument<PatchBoardRequest> request)
  {
    throw new NotImplementedException();
  }
}
