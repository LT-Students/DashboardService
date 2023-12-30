using LT.DigitalOffice.DashboardService.Business.Comment.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Comment.Filters;
using LT.DigitalOffice.Kernel.Responses;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Comment;

public class GetCommentsCommand : IGetCommentsCommand
{
  private readonly ICommentRepository _repository;

  public GetCommentsCommand(ICommentRepository repository)
  {
    _repository = repository;
  }

  public Task<FindResultResponse<CommentInfo>> ExecuteAsync(GetCommentsFilter filter)
  {
    throw new System.NotImplementedException();
  }
}