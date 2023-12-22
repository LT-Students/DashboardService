using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;

namespace LT.DigitalOffice.DashboardService.Mappers.Responses.Interfaces;

public interface IChangeLogResponseMapper
{
  public ChangeLogResponse Map(DbChangeLog dbChangeLog);
}
