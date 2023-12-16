using FluentValidation;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Group;

namespace LT.DigitalOffice.DashboardService.Validation.Group.Interfaces;

public interface ICreateGroupRequestValidator : IValidator<CreateGroupRequest> { }