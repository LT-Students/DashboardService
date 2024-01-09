using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority;
using LT.DigitalOffice.Kernel.Attributes;
using Microsoft.AspNetCore.JsonPatch;

namespace LT.DigitalOffice.DashboardService.Mappers.Edit.Interfaces;

[AutoInject]
public interface IEditDbPriorityMapper
{
  JsonPatchDocument<DbPriority> Map(JsonPatchDocument<EditPriorityRequest> request);
}