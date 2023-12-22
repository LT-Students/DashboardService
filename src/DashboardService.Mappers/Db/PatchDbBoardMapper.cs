using LT.DigitalOffice.DashboardService.Mappers.Db.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board;
using Microsoft.AspNetCore.JsonPatch;
using System;

namespace LT.DigitalOffice.DashboardService.Mappers.Db;

public class PatchDbBoardMapper : IPatchDbBoardMapper
{
  public JsonPatchDocument<DbBoard> Map(JsonPatchDocument<PatchBoardRequest> request, Guid modifiedById)
  {
    throw new NotImplementedException();
  }
}
