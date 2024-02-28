using DigitalOffice.Models.Broker.Models.User;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using LT.DigitalOffice.Kernel.Attributes;
using System.Collections.Generic;

namespace LT.DigitalOffice.DashboardService.Mappers.Responses.Interfaces;

[AutoInject]
public interface IBoardResponseMapper
{
  public BoardResponse Map(DbBoard dbBoard, List<UserData> usersData);
}
