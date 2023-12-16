using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Comment;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Comment.Interfaces;

public interface IEditCommentCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid id, PatchCommentRequest request);
}