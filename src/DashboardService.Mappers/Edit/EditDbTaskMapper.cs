using LT.DigitalOffice.DashboardService.Mappers.Edit.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace LT.DigitalOffice.DashboardService.Mappers.Edit;

public class EditDbTaskMapper : IEditDbTaskMapper
{
  public JsonPatchDocument<DbTask> Map(JsonPatchDocument<EditTaskRequest> request)
  {
    JsonPatchDocument<DbTask> result = new();
    
    foreach (Operation<EditTaskRequest> item in request.Operations)
    {
      result.Operations.Add(new Operation<DbTask>(item.op, item.path, item.from, item.value));
    }

    return result;
  }
}