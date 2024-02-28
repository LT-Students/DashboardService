using FluentValidation;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.DashboardUser;
using LT.DigitalOffice.DashboardService.Validation.DashboardUser.Interfaces;

namespace LT.DigitalOffice.DashboardService.Validation.DashboardUser;

public class CreateDashboardUsersValidator : AbstractValidator<CreateDashboardUsersRequest>, ICreateDashboardUsersValidator
{
  public CreateDashboardUsersValidator(
    IBoardRepository repository,
    ICreateUsersValidator usersValidator)
  {
    RuleFor(request => request.DashboardId)
      .NotEmpty().WithMessage("Dashboard id can not be empty.")
      .MustAsync(async (i, _) => await repository.ExistAsync(i))
      .WithMessage("The department id does not exist.");

    RuleFor(request => request.Users)
      .NotEmpty()
      .WithMessage("List of users must contain at least one user.")
      .SetValidator(usersValidator);
  }
}