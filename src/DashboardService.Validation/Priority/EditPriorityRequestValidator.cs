using FluentValidation;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority;
using LT.DigitalOffice.DashboardService.Validation.Priority.Interfaces;
using LT.DigitalOffice.Kernel.Validators;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Validation.Priority;

public class EditPriorityRequestValidator : ExtendedEditRequestValidator<Guid, EditPriorityRequest>, IEditPriorityRequestValidator
{
  private readonly IPriorityRepository _priorityRepository;

  public EditPriorityRequestValidator(IPriorityRepository priorityRepository)
  {
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
    Operation<EditPriorityRequest> requestedOperation,
    Guid priorityId,
    ValidationContext<(Guid, JsonPatchDocument<EditPriorityRequest>)> context,
    CancellationToken ct)
  {
    RequestedOperation = requestedOperation;
    Context = context;
    
    AddCorrectPaths(
      new List<string>
      {
        nameof(EditPriorityRequest.Name),
      });
    
    AddCorrectOperations(nameof(EditPriorityRequest.Name), new() { OperationType.Replace });
    
    AddFailureForPropertyIfNot(
      nameof(EditPriorityRequest.Name),
      x => x == OperationType.Replace,
      new()
      {
        { x => !string.IsNullOrEmpty(x.value?.ToString().Trim()), "Name must not be empty." },
        { x => x.value.ToString().Trim().Length <= 50, "Name is too long." },
        
      }, CascadeMode.Stop);

    await AddFailureForPropertyIfNotAsync(
      nameof(EditPriorityRequest.Name),
      x => x == OperationType.Replace,
      new()
      {
        {
          async x =>
            !await _priorityRepository.NameExistAsync(x.value?.ToString(), ct, priorityId),
            "This priority name already exist."
        },
      });
  }
}