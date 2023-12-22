using FluentValidation;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task;
using LT.DigitalOffice.Kernel.Attributes;

namespace LT.DigitalOffice.DashboardService.Validation.Tasks.Interfaces;

[AutoInject]
public interface IPatchTaskRequestValidator : IValidator<PatchTaskRequest> { }