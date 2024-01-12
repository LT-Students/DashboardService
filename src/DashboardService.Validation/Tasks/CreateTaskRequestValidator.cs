using FluentValidation;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task;
using LT.DigitalOffice.DashboardService.Validation.Tasks.Interfaces;
using System;

namespace LT.DigitalOffice.DashboardService.Validation.Tasks;

public class CreateTaskRequestValidator : AbstractValidator<CreateTaskRequest>, ICreateTaskRequestValidator
{
  public CreateTaskRequestValidator(
    ITaskRepository tasksRepository,
    ITaskTypeRepository taskTypeRepository,
    IPriorityRepository priorityRepository)
  {
    // TODO: Waiting for Group Repository in develop
    /*RuleFor(request => request.GroupId)
      .NotEmpty()
      .WithMessage("GroupId must not be empty.")
      .MustAsync((groupId, _) => groupRepository.ExistAsync(groupId.Value))
      .WithMessage("This group id doesn't exist.");*/
    
    RuleFor(request => request.Name)
      .NotEmpty()
      .WithMessage("Task name is empty.")
      .MaximumLength(50)
      .WithMessage("Task name is too long.");

    RuleFor(request => request.Content)
      .NotEmpty().
      WithMessage("Task content is empty.");
    
    When(request => request.TaskTypeId.HasValue, () =>
    {
      RuleFor(request => request.TaskTypeId)
        .NotEmpty()
        .WithMessage("TaskTypeId must not be default.")
        .MustAsync((taskTypeId, ct) => taskTypeRepository.ExistAsync(taskTypeId.Value, ct))
        .WithMessage("This task type id doesn't exist.");
    });
    
    When(request => request.PriorityId.HasValue, () =>
    {
      RuleFor(request => request.PriorityId)
        .NotEmpty()
        .WithMessage("PriorityId must not be default.")
        .MustAsync((priorityId, ct) => priorityRepository.ExistAsync(priorityId.Value, ct))
        .WithMessage("This priority id doesn't exist.");
    });
    
    When(request => request.DeadlineAtUtc.HasValue, () =>
    {
      RuleFor(request => request.DeadlineAtUtc)
        .NotEmpty()
        .WithMessage("DeadlineAtUtc must not be default.")
        .Must(t => t.Value > DateTime.UtcNow)
        .WithMessage("DeadlineAtUtc is incorrect.");
    });
  }
}