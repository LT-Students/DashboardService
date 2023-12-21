using FluentValidation;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task;
using LT.DigitalOffice.Kernel.Attributes;

namespace LT.DigitalOffice.DashboardService.Validation.Task.Interfaces;

[AutoInject]
public interface ICreateTaskRequestValidator: IValidator<CreateTaskRequest> { }