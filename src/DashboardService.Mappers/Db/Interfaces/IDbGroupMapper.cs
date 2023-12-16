using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Group;
using LT.DigitalOffice.Kernel.Attributes;

namespace LT.DigitalOffice.DashboardService.Mappers.Db.Interfaces;

[AutoInject]
public interface IDbGroupMapper
{
  DbGroup Map(CreateGroupRequest request);
}