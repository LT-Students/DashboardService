using FluentValidation;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog;
using LT.DigitalOffice.Kernel.Attributes;

namespace LT.DigitalOffice.DashboardService.Validation.ChangeLog.Interfaces;

[AutoInject]
public interface IEditChangeLogValidator : IValidator<PatchChangeLogRequest>
{
}
