using FluentValidation;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board;
using LT.DigitalOffice.Kernel.Attributes;
using Microsoft.AspNetCore.JsonPatch;
using System;

namespace LT.DigitalOffice.DashboardService.Validation.Board.Interfaces;

[AutoInject]
public interface IEditBoardRequestValidator : IValidator<(DbBoard, JsonPatchDocument<PatchBoardRequest>)>
{
}
