using FluentValidation;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority;
using LT.DigitalOffice.Kernel.Attributes;
using Microsoft.AspNetCore.JsonPatch;
using System;

namespace LT.DigitalOffice.DashboardService.Validation.Priority.Interfaces;

[AutoInject]
public interface IEditPriorityRequestValidator : IValidator<(Guid, JsonPatchDocument<EditPriorityRequest>)> { }