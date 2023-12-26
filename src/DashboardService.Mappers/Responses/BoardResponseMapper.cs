using LT.DigitalOffice.DashboardService.Mappers.Responses.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;

namespace LT.DigitalOffice.DashboardService.Mappers.Responses;

public class BoardResponseMapper : IBoardResponseMapper
{
  public BoardResponse Map(DbBoard dbBoard)
  {
    return new BoardResponse
    {
      Id = dbBoard.Id,
      ProjectId = dbBoard.ProjectId,
      Name = dbBoard.Name,
      IsActive = dbBoard.IsActive,
      // Groups = dbBoard.Groups
    };
  }
}
