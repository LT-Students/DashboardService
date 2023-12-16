using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Comment.Interfaces;

public interface IGetCommentCommand
{
  Task<OperationResultResponse<CommentResponse>> ExecuteAsync(Guid id);
}