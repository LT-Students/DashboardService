using LT.DigitalOffice.DashboardService.Business.Priority.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Mappers.Models.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.Kernel.Helpers.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Priority;

public class GetPriorityCommand : IGetPriorityCommand
{
  private readonly IPriorityRepository _priorityRepository;
  private readonly IResponseCreator _responseCreator;
  private readonly IPriorityInfoMapper _priorityInfoMapper;

  public GetPriorityCommand(
    IPriorityRepository priorityRepository,
    IResponseCreator responseCreator,
    IPriorityInfoMapper priorityInfoMapper)
  {
    _priorityRepository = priorityRepository;
    _responseCreator = responseCreator;
    _priorityInfoMapper = priorityInfoMapper;
  }
  
  public async Task<OperationResultResponse<PriorityInfo>> ExecuteAsync(Guid id, CancellationToken ct)
  {
    DbPriority dbPriority = await _priorityRepository.GetAsync(id, ct);

    if (dbPriority is null)
    {
      return _responseCreator.CreateFailureResponse<PriorityInfo>(HttpStatusCode.NotFound);
    }

    return new()
    {
      Body = _priorityInfoMapper.Map(dbPriority)
    };
  }
}