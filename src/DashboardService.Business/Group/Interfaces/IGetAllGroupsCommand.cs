using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.Kernel.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Group.Interfaces;

public interface IGetAllGroupsCommand
{
  Task<FindResultResponse<IEnumerable<GroupInfo>>> ExecuteAsync();
}