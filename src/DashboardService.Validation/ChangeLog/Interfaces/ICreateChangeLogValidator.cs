using FluentValidation;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog;

namespace LT.DigitalOffice.DashboardService.Validation.ChangeLog.Interfaces;

public interface ICreateChangeLogValidator : IValidator<CreateChangeLogRequest>
{
}
