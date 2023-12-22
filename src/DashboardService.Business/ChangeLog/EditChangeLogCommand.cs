using LT.DigitalOffice.DashboardService.Business.ChangeLog.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog;
using LT.DigitalOffice.Kernel.BrokerSupport.AccessValidatorEngine.Interfaces;
using LT.DigitalOffice.Kernel.Helpers.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.ChangeLog;

public class EditChangeLogCommand : IEditChangeLogCommand
{
  private readonly IChangeLogRepository _repository;
  private readonly IResponseCreator _responseCreator;
  private readonly IAccessValidator _accessValidator;

  public EditChangeLogCommand(IChangeLogRepository repository)
  {
    _repository = repository;
  }

  public Task<OperationResultResponse<bool>> ExecuteAsync(Guid id, JsonPatchDocument<EditChangeLogRequest> request)
  {
    throw new NotImplementedException();
  }
}
