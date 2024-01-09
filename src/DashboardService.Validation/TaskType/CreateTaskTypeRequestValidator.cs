using FluentValidation;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.TaskType;
using LT.DigitalOffice.DashboardService.Validation.TaskType.Interfaces;

namespace LT.DigitalOffice.DashboardService.Validation.TaskType;

public class CreateTaskTypeRequestValidator : AbstractValidator<CreateTaskTypeRequest>, ICreateTaskTypeRequestValidator
{
  public CreateTaskTypeRequestValidator(ITaskTypeRepository repository)
  {
    RuleFor(request => request)
      .NotNull()
      .WithMessage("Empty request.");

    RuleFor(request => request.Name)
      .MaximumLength(50)
      .WithMessage("Task type name is too long.")
      .MustAsync(async (request, ct) => !await repository.NameExistAsync(request, ct))
      .WithMessage("Task type name already exists.");
  }
}