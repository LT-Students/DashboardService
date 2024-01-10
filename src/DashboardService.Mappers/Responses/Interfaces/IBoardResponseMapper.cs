using LT.DigitalOffice.DashboardService.Mappers.Models.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using LT.DigitalOffice.Kernel.Attributes;
using System;
using System.Text.RegularExpressions;

namespace LT.DigitalOffice.DashboardService.Mappers.Responses.Interfaces;

[AutoInject]
public interface IBoardResponseMapper
{
  public BoardResponse Map(DbBoard dbBoard);
}
