using FluentValidation;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task;
using LT.DigitalOffice.DashboardService.Validation.Tasks.Interfaces;
using LT.DigitalOffice.Kernel.Validators;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Validation.Tasks;

public class EditTaskRequestValidator : ExtendedEditRequestValidator<Guid, EditTaskRequest>, IEditTaskRequestValidator
{
  private readonly ITaskRepository _repository;
  private readonly ITaskTypeRepository _taskTypeRepository;
  private readonly IPriorityRepository _priorityRepository;

  public EditTaskRequestValidator(
    ITaskRepository repository,
    ITaskTypeRepository taskTypeRepository,
    IPriorityRepository priorityRepository)
  {
    _repository = repository;
    _taskTypeRepository = taskTypeRepository;
    _priorityRepository = priorityRepository;

    RuleFor(x => x)
      .CustomAsync(async (x, context, ct) =>
      {
        foreach (var op in x.Item2.Operations)
        {
          await HandleInternalPropertyValidationAsync(op, x.Item1, context, ct);
        }
      });
  }
  
  private async Task HandleInternalPropertyValidationAsync(
    Operation<EditTaskRequest> requestedOperation,
    Guid taskId,
    ValidationContext<(Guid, JsonPatchDocument<EditTaskRequest>)> context,
    CancellationToken ct)
  {
    RequestedOperation = requestedOperation;
    Context = context;
    
    AddCorrectPaths(
      new List<string>
      {
        nameof(EditTaskRequest.Name),
        nameof(EditTaskRequest.Content),
        nameof(EditTaskRequest.TaskTypeId),
        nameof(EditTaskRequest.PriorityId),
        nameof(EditTaskRequest.DeadlineAtUtc),
      });
    
    AddCorrectOperations(nameof(EditTaskRequest.Name), new() { OperationType.Replace });
    AddCorrectOperations(nameof(EditTaskRequest.Content), new() { OperationType.Replace });
    AddCorrectOperations(nameof(EditTaskRequest.TaskTypeId), new() { OperationType.Replace });
    AddCorrectOperations(nameof(EditTaskRequest.PriorityId), new() { OperationType.Replace });
    AddCorrectOperations(nameof(EditTaskRequest.DeadlineAtUtc), new() { OperationType.Replace });
    
    AddFailureForPropertyIfNot(
      nameof(EditTaskRequest.Name),
      x => x == OperationType.Replace,
      new()
      {
        { x => !string.IsNullOrEmpty(x.value?.ToString().Trim()), "Name must not be empty." },
        { x => x.value.ToString().Trim().Length <= 50, "Name is too long." },
        
      }, CascadeMode.Stop);
    
    AddFailureForPropertyIfNot(
      nameof(EditTaskRequest.Content),
      x => x == OperationType.Replace,
      new()
      {
        { x => !string.IsNullOrEmpty(x.value?.ToString().Trim()), "Content must not be empty." },
      }, CascadeMode.Stop);
    
    AddFailureForPropertyIfNot(
      nameof(EditTaskRequest.DeadlineAtUtc),
      x => x == OperationType.Replace,
      new()
      {
        {
          x =>
          {
            string deadLineStr = x.value?.ToString();
            
            if (deadLineStr is null)
            {
              return true;
            }

            return DateTime.TryParse(deadLineStr, out DateTime deadLineAtUtc) && deadLineAtUtc > DateTime.UtcNow;
          }, "DeadlineAtUtc cannot be less then Utc now." },
      }, CascadeMode.Stop);
    
    await AddFailureForPropertyIfNotAsync(
      nameof(EditTaskRequest.TaskTypeId),
      x => x == OperationType.Replace,
      new()
      {
        {
          async x =>
          {
            string taskTypeIdStr = x.value?.ToString();
            
            if (taskTypeIdStr is null)
            {
              return true;
            }

            return Guid.TryParse(taskTypeIdStr, out Guid taskTypeId) && await _taskTypeRepository.ExistAsync(taskTypeId, ct);
          },
          "Task type id doesn`t exist."
        }
      }
    );
    
    await AddFailureForPropertyIfNotAsync(
      nameof(EditTaskRequest.PriorityId),
      x => x == OperationType.Replace,
      new()
      {
        {
          async x =>
          {
            string priorityIdStr = x.value?.ToString();
            
            if (priorityIdStr is null)
            {
              return true;
            }

            return Guid.TryParse(priorityIdStr, out Guid taskTypeId) && await _priorityRepository.ExistAsync(taskTypeId, ct);
          },
          "Priority id doesn`t exist."
        }
      }
    );
  }
}