using FluentValidation;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.TaskType;
using LT.DigitalOffice.Kernel.Attributes;

namespace LT.DigitalOffice.DashboardService.Validation.TaskType.Interfaces;

[AutoInject]
public interface IPatchTaskTypeRequestValidator : IValidator<PatchTaskTypeRequest> { }