using LT.DigitalOffice.DashboardService.Mappers.Db.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using System;

namespace LT.DigitalOffice.DashboardService.Mappers.Db;

public class PatchDbBoardMapper : IPatchDbBoardMapper
{
  public JsonPatchDocument<DbBoard> Map(JsonPatchDocument<PatchBoardRequest> request)
  {
    JsonPatchDocument<DbBoard> result = new();

    foreach (Operation<PatchBoardRequest> item in request.Operations)
    {
      result.Operations.Add(new Operation<DbBoard>(item.op, item.path, item.from, item.value));
    }

    return result;
  }
}
