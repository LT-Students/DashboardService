using FluentValidation;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.TaskType;
using LT.DigitalOffice.DashboardService.Validation.TaskType.Interfaces;
using LT.DigitalOffice.Kernel.Validators;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Validation.TaskType;

public class EditTaskTypeRequestValidator : ExtendedEditRequestValidator<Guid, EditTaskTypeRequest>, IEditTaskTypeRequestValidator
{
  private readonly ITaskTypeRepository _taskTypeRepository;

  public EditTaskTypeRequestValidator(ITaskTypeRepository repository)
  {
    _taskTypeRepository = repository;
    
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
    Operation<EditTaskTypeRequest> requestedOperation,
    Guid taskTypeId,
    ValidationContext<(Guid, JsonPatchDocument<EditTaskTypeRequest>)> context,
    CancellationToken ct)
  {
    RequestedOperation = requestedOperation;
    Context = context;

    AddCorrectPaths(
      new List<string>
      {
        nameof(EditTaskTypeRequest.Name),
      });

    AddCorrectOperations(nameof(EditTaskTypeRequest.Name), new() { OperationType.Replace });

    AddFailureForPropertyIfNot(
      nameof(EditTaskTypeRequest.Name),
      x => x == OperationType.Replace,
      new()
      {
        { x => !string.IsNullOrEmpty(x.value?.ToString().Trim()), "Name must not be empty." },
        { x => x.value.ToString().Trim().Length < 51, "Name is too long." },

      }, CascadeMode.Stop);

    await AddFailureForPropertyIfNotAsync(
      nameof(EditTaskTypeRequest.Name),
      x => x == OperationType.Replace,
      new()
      {
        {
          async x => !await _taskTypeRepository.NameExistAsync(x.value?.ToString(), ct, taskTypeId),
          "This task type name already exist."
        },
      });
  }
}