using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.TaskType;
using LT.DigitalOffice.Kernel.Attributes;
using Microsoft.AspNetCore.JsonPatch;

namespace LT.DigitalOffice.DashboardService.Mappers.Edit.Interfaces;

[AutoInject]
public interface IEditDbTaskTypeMapper
{
  JsonPatchDocument<DbTaskType> Map(JsonPatchDocument<EditTaskTypeRequest> request);
}