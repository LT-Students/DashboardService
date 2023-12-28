using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Comment;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Comment.Interfaces;

[AutoInject]
public interface IEditCommentCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid id, JsonPatchDocument<EditCommentRequest> request);
}