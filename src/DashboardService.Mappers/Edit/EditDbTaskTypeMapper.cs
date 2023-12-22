using LT.DigitalOffice.DashboardService.Mappers.Edit.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.TaskType;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace LT.DigitalOffice.DashboardService.Mappers.Edit;

public class EditDbTaskTypeMapper : IEditDbTaskTypeMapper
{
  public JsonPatchDocument<DbTaskType> Map(JsonPatchDocument<EditTaskTypeRequest> request)
  {
    JsonPatchDocument<DbTaskType> result = new();
    
    foreach (Operation<EditTaskTypeRequest> item in request.Operations)
    {
      result.Operations.Add(new Operation<DbTaskType>(item.op, item.path, item.from, item.value));
    }

    return result;
  }
}