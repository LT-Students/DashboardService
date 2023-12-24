using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task;
using LT.DigitalOffice.Kernel.Attributes;
using Microsoft.AspNetCore.JsonPatch;

namespace LT.DigitalOffice.DashboardService.Mappers.Edit.Interfaces;

[AutoInject]
public interface IEditDbTaskMapper
{
  JsonPatchDocument<DbTask> Map(JsonPatchDocument<EditTaskRequest> request);
}