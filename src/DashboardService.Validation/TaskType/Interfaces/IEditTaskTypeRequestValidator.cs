using FluentValidation;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.TaskType;
using LT.DigitalOffice.Kernel.Attributes;
using Microsoft.AspNetCore.JsonPatch;
using System;

namespace LT.DigitalOffice.DashboardService.Validation.TaskType.Interfaces;

[AutoInject]
public interface IEditTaskTypeRequestValidator : IValidator<(Guid, JsonPatchDocument<EditTaskTypeRequest>)> { }