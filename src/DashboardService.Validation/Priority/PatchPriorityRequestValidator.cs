using FluentValidation;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority;
using LT.DigitalOffice.DashboardService.Validation.Priority.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LT.DigitalOffice.DashboardService.Validation.Priority;

public class PatchPriorityRequestValidator : AbstractValidator<PatchPriorityRequest>, IPatchPriorityRequestValidator
{
  public PatchPriorityRequestValidator([FromServices] IPriorityRepository repository)
  {
    
  }
}