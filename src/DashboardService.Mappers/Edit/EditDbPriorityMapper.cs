using LT.DigitalOffice.DashboardService.Mappers.Edit.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace LT.DigitalOffice.DashboardService.Mappers.Edit;

public class EditDbPriorityMapper : IEditDbPriorityMapper
{
  public JsonPatchDocument<DbPriority> Map(JsonPatchDocument<EditPriorityRequest> request)
  {
    JsonPatchDocument<DbPriority> result = new();
    
    foreach (Operation<EditPriorityRequest> item in request.Operations)
    {
      result.Operations.Add(new Operation<DbPriority>(item.op, item.path, item.from, item.value));
    }

    return result;
  }
}