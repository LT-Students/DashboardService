﻿using FluentValidation;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board;
using LT.DigitalOffice.DashboardService.Validation.Board.Interfaces;
using LT.DigitalOffice.Kernel.Validators;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using System;
using System.Collections.Generic;
using System.Threading;


namespace LT.DigitalOffice.DashboardService.Validation.Board;

public class EditBoardRequestValidator : ExtendedEditRequestValidator<Guid, PatchBoardRequest>, IEditBoardRequestValidator
{
  private readonly IBoardRepository _boardRepository;

  public EditBoardRequestValidator(IBoardRepository repository)
  {
    _boardRepository = repository;

    RuleFor(x => x)
      .CustomAsync(async (x, context, ct) =>
      {
        DbBoard board = await _boardRepository.GetAsync(x.Item1, new(), ct);

        foreach (Operation<PatchBoardRequest> op in x.Item2.Operations)
        {
          await HandleInternalPropertyValidationAsync(op, board, context, ct);
        }
      });
  }

  private async System.Threading.Tasks.Task HandleInternalPropertyValidationAsync(
    Operation<PatchBoardRequest> requestedOperation,
    DbBoard board,
    ValidationContext<(Guid, JsonPatchDocument<PatchBoardRequest>)> context,
    CancellationToken ct)
  {
    RequestedOperation = requestedOperation;
    Context = context;

    AddCorrectPaths(
      new List<string>
      {
        nameof(PatchBoardRequest.Name),
        nameof(PatchBoardRequest.IsActive)
      });

    AddCorrectOperations(nameof(PatchBoardRequest.Name), new() { OperationType.Replace });
    AddCorrectOperations(nameof(PatchBoardRequest.IsActive), new() { OperationType.Replace });

    AddFailureForPropertyIfNot(
      nameof(PatchBoardRequest.Name),
      x => x == OperationType.Replace,
      new()
      {
        { x => !string.IsNullOrEmpty(x.value?.ToString().Trim()), "Name must not be empty." },
        { x => x.value.ToString().Trim().Length < 51, "Name is too long." },

      }, CascadeMode.Stop);

    await AddFailureForPropertyIfNotAsync(
      nameof(PatchBoardRequest.Name),
      x => x == OperationType.Replace,
      new()
      {
        {
          async x => !await _boardRepository.NameExistAsync(x.value?.ToString(), board.ProjectId, ct, board.Id),
            "This board name already exist."
        },
      });

    AddFailureForPropertyIfNot(
      nameof(PatchBoardRequest.IsActive),
      x => x == OperationType.Replace,
      new()
      {
        { x => bool.TryParse(x.value?.ToString(), out bool _), "isActive is not correct" },
      });
  }
}
