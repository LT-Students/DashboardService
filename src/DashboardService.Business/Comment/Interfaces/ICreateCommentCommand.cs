using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Comment;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Comment.Interfaces;

public interface ICreateCommentCommand
{
  Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateCommentRequest request);
}