using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Comment;
using LT.DigitalOffice.Kernel.Attributes;

namespace LT.DigitalOffice.DashboardService.Mappers.Db.Interfaces;

[AutoInject]
public interface IDbCommentMapper
{
  DbComment Map(CreateCommentRequest request);
}