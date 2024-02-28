using FluentValidation;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.DashboardUser;
using LT.DigitalOffice.Kernel.Attributes;
using System.Collections.Generic;

namespace LT.DigitalOffice.DashboardService.Validation.DashboardUser.Interfaces;

[AutoInject]
public interface ICreateUsersValidator : IValidator<List<CreateUserRequest>>
{
}