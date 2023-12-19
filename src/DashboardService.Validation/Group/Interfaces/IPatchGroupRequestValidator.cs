using FluentValidation;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Group;
using LT.DigitalOffice.Kernel.Attributes;

namespace LT.DigitalOffice.DashboardService.Validation.Group.Interfaces;

[AutoInject]
public interface IPatchGroupRequestValidator : IValidator<PatchGroupRequest> { }