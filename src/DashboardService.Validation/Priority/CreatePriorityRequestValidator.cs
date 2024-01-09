using FluentValidation;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority;
using LT.DigitalOffice.DashboardService.Validation.Priority.Interfaces;

namespace LT.DigitalOffice.DashboardService.Validation.Priority;

public class CreatePriorityRequestValidator : AbstractValidator<CreatePriorityRequest>, ICreatePriorityRequestValidator
{
  public CreatePriorityRequestValidator(IPriorityRepository repository)
  {
    RuleFor(request => request)
      .NotNull()
      .WithMessage("Empty request.");
    
    RuleFor(request => request.Name)
      .MaximumLength(50)
      .WithMessage("Task priority name is too long.")
      .MustAsync(async (request, ct) => !await repository.NameExistAsync(request, ct))
      .WithMessage("Task priority name already exists.");
  }
}