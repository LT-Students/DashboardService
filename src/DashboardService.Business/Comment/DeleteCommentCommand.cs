using LT.DigitalOffice.DashboardService.Business.Comment.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Comment;

public class DeleteCommentCommand : IDeleteCommentCommand
{
  private readonly ICommentRepository _repository;

  public DeleteCommentCommand(ICommentRepository repository)
  {
    _repository = repository;
  }

  public Task<OperationResultResponse<bool>> ExecuteAsync(Guid id)
  {
    throw new NotImplementedException();
  }
}