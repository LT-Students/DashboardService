using FluentValidation;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.TaskType;

namespace LT.DigitalOffice.DashboardService.Validation.TaskType.Interfaces;

public interface IPatchTaskTypeRequestValidator : IValidator<PatchTaskTypeRequest> { }