using LT.DigitalOffice.DashboardService.Mappers.Models.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;

namespace LT.DigitalOffice.DashboardService.Mappers.Models;

public class BoardInfoMapper : IBoardInfoMapper
{
  public BoardInfo Map(DbBoard dbBoard)
  {
    return dbBoard is null
      ? null
      : new BoardInfo
      {
        Id = dbBoard.Id,
        ProjectId = dbBoard.ProjectId,
        Name = dbBoard.Name,
        IsActive = dbBoard.IsActive,
        // Groups = dbBoard.Groups
      };
  }
}
