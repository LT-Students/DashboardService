using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using LT.DigitalOffice.Kernel.Attributes;

namespace LT.DigitalOffice.DashboardService.Mappers.Responses.Interfaces;

[AutoInject]
public interface ITaskResponseMapper
{
  TaskResponse Map(DbTask dbTask);
}