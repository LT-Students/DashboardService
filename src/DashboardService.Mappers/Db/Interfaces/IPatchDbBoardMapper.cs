using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board;
using LT.DigitalOffice.Kernel.Attributes;
using Microsoft.AspNetCore.JsonPatch;

namespace LT.DigitalOffice.DashboardService.Mappers.Db.Interfaces;

[AutoInject]
public interface IPatchDbBoardMapper
{
  JsonPatchDocument<DbBoard> Map(JsonPatchDocument<PatchBoardRequest> request);
}
