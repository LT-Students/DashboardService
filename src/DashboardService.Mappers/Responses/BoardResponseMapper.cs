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
  private readonly IGroupInfoMapper _groupInfoMapper;

  public BoardResponseMapper(IGroupInfoMapper groupInfoMapper)
  {
    _groupInfoMapper = groupInfoMapper;
  }

  public BoardResponse Map(DbBoard dbBoard)
  {
    return new BoardResponse
    {
      Id = dbBoard.Id,
      ProjectId = dbBoard.ProjectId,
      Name = dbBoard.Name,
      IsActive = dbBoard.IsActive,
      Groups = dbBoard.Groups.Select(_groupInfoMapper.Map).ToList()
    };
  }
}
