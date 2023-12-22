using LT.DigitalOffice.DashboardService.Business.Priority.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Mappers.Models.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority.Filters;
using LT.DigitalOffice.Kernel.Responses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Priority;

public class GetPrioritiesCommand : IGetPrioritiesCommand
{
  private readonly IPriorityRepository _priorityRepository;
  private readonly IPriorityInfoMapper _priorityInfoMapper;

  public GetPrioritiesCommand(
    IPriorityRepository priorityRepository,
    IPriorityInfoMapper priorityInfoMapper)
  {
    _priorityRepository = priorityRepository;
    _priorityInfoMapper = priorityInfoMapper;
  }
  
  public async Task<FindResultResponse<PriorityInfo>> ExecuteAsync(GetPrioritiesFilter filter, CancellationToken ct)
  {
    (List<DbPriority> dbPriorities, int totalCount) result = await _priorityRepository.GetAllAsync(filter, ct);

    return new()
    {
      Body = result.dbPriorities.ConvertAll(_priorityInfoMapper.Map), 
      TotalCount = result.totalCount
    };
  }
}