using FluentValidation;
using LT.DigitalOffice.DashboardService.Broker.Requests.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.DashboardUser;
using LT.DigitalOffice.DashboardService.Validation.DashboardUser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LT.DigitalOffice.DashboardService.Validation.DashboardUser;

public class CreateUsersValidator : AbstractValidator<List<CreateUserRequest>>, ICreateUsersValidator
{
  public CreateUsersValidator(
    IUserService userService)
  {
    RuleFor(request => request)
      .MustAsync(async (request, _) =>
      {
        List<Guid> usersIds = request.Select(r => r.UserId).ToList();
        return usersIds.Distinct().Count() == usersIds.Count
               && (await userService.CheckUsersExistenceAsync(usersIds)).Count == usersIds.Count;
      })
      .WithMessage("Some users does not exist.");
  }
}