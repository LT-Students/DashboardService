using FluentValidation;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog;
using LT.DigitalOffice.DashboardService.Validation.ChangeLog.Interfaces;

namespace LT.DigitalOffice.DashboardService.Validation.ChangeLog;

public class EditChangeLogValidator : AbstractValidator<EditChangeLogRequest>, IEditChangeLogValidator
{
  public EditChangeLogValidator(IChangeLogRepository changeLogRepository)
  {
  }
}
