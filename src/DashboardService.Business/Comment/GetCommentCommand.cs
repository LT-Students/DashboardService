using LT.DigitalOffice.DashboardService.Business.Comment.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Comment.Filters;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Comment;

public class GetCommentCommand : IGetCommentCommand
{
  private readonly ICommentRepository _repository;

  public GetCommentCommand(ICommentRepository repository)
  {
    _repository = repository;
  }

  public Task<OperationResultResponse<CommentResponse>> ExecuteAsync(Guid id, GetCommentFilter filter)
  {
    throw new NotImplementedException();
  }
}