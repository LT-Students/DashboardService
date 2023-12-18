using FluentValidation;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task;
using LT.DigitalOffice.DashboardService.Validation.Task.Interfaces;

namespace LT.DigitalOffice.DashboardService.Validation.Task;

public class PatchTaskRequestValidator : AbstractValidator<PatchTaskRequest>, IPatchTaskRequestValidator
{
  
}