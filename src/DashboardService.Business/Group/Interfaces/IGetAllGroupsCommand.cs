using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Group.Interfaces;

[AutoInject]
public interface IGetAllGroupsCommand
{
  Task<FindResultResponse<GroupInfo>> ExecuteAsync();
}