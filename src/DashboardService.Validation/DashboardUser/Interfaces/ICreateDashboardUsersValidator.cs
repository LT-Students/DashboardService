using FluentValidation;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.DashboardUser;
using LT.DigitalOffice.Kernel.Attributes;

namespace LT.DigitalOffice.DashboardService.Validation.DashboardUser.Interfaces;

[AutoInject]
public interface ICreateDashboardUsersValidator : IValidator<CreateDashboardUsersRequest>
{
}