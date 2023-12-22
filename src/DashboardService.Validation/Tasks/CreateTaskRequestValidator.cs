using FluentValidation;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task;
using LT.DigitalOffice.DashboardService.Validation.Tasks.Interfaces;

namespace LT.DigitalOffice.DashboardService.Validation.Tasks;

public class CreateTaskRequestValidator : AbstractValidator<CreateTaskRequest>, ICreateTaskRequestValidator
{
  public CreateTaskRequestValidator(ITaskRepository repository)
  {
  }
}