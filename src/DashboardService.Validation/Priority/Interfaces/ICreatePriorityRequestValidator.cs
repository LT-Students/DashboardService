using FluentValidation;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority;
using LT.DigitalOffice.Kernel.Attributes;

namespace LT.DigitalOffice.DashboardService.Validation.Priority.Interfaces;

[AutoInject]
public interface ICreatePriorityRequestValidator : IValidator<CreatePriorityRequest> { }