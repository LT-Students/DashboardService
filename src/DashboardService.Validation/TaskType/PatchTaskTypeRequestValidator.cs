using FluentValidation;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.TaskType;
using LT.DigitalOffice.DashboardService.Validation.TaskType.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LT.DigitalOffice.DashboardService.Validation.TaskType;

public class PatchTaskTypeRequestValidator : AbstractValidator<PatchTaskTypeRequest>, IPatchTaskTypeRequestValidator
{
  public PatchTaskTypeRequestValidator(ITaskTypeRepository repository)
  {
    
  }
}