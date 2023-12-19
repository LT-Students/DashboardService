using LT.DigitalOffice.DashboardService.Business.Comment.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.Kernel.Responses;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Comment;

public class GetAllCommentsCommand : IGetAllCommentsCommand
{
  private readonly ICommentRepository _repository;

  public GetAllCommentsCommand(ICommentRepository repository)
  {
    _repository = repository;
  }

  public Task<FindResultResponse<CommentInfo>> ExecuteAsync()
  {
    throw new System.NotImplementedException();
  }
}