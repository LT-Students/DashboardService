using FluentValidation;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task;
using LT.DigitalOffice.Kernel.Attributes;
using Microsoft.AspNetCore.JsonPatch;
using System;

namespace LT.DigitalOffice.DashboardService.Validation.Tasks.Interfaces;

[AutoInject]
public interface IEditTaskRequestValidator : IValidator<(Guid, JsonPatchDocument<EditTaskRequest>)> { }