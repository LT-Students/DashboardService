using LT.DigitalOffice.DashboardService.Mappers.Models;
using LT.DigitalOffice.DashboardService.Mappers.Models.Interfaces;
using LT.DigitalOffice.DashboardService.Mappers.Responses.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using System;
using System.Linq;

namespace LT.DigitalOffice.DashboardService.Mappers.Responses;

public class BoardResponseMapper : IBoardResponseMapper
{
  public BoardResponse Map(DbBoard dbBoard, Func<DbGroup, GroupInfo> map)
  {
    return new BoardResponse
    {
      Id = dbBoard.Id,
      ProjectId = dbBoard.ProjectId,
      Name = dbBoard.Name,
      IsActive = dbBoard.IsActive,
      Groups = dbBoard.Groups.Select(map).ToList()
    };
  }
}
