using LT.DigitalOffice.DashboardService.Business.ChangeLog.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.ChangeLog;

public class CreateChangeLogCommand : ICreateChangeLogCommand
{
  private readonly IChangeLogRepository _repository;

  public CreateChangeLogCommand(IChangeLogRepository repository)
  {
    _repository = repository;
  }

  public Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateChangeLogRequest request)
  {
    throw new NotImplementedException();
  }
}
