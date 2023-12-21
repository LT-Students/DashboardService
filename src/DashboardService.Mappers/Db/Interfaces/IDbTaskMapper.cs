using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task;
using LT.DigitalOffice.Kernel.Attributes;
using System;

namespace LT.DigitalOffice.DashboardService.Mappers.Db.Interfaces;

[AutoInject]
public interface IDbTaskMapper
{
  DbTask Map(Guid createdBy, CreateTaskRequest request);
}