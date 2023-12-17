using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Comment;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Comment.Interfaces;

[AutoInject]
public interface ICreateCommentCommand
{
  Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateCommentRequest request);
}