using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Comment.Filters;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Comment.Interfaces;

[AutoInject]
public interface IGetCommentCommand
{
  Task<OperationResultResponse<CommentResponse>> ExecuteAsync(Guid id, GetCommentFilter filter);
}