using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.TaskType;
using LT.DigitalOffice.Kernel.Attributes;

namespace LT.DigitalOffice.DashboardService.Mappers.Db.Interfaces;

[AutoInject]
public interface IDbTaskTypeMapper
{
  DbTaskType Map(CreateTaskTypeRequest request);
}