using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Comment.Interfaces;

public interface IDeleteCommentCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid id);
}