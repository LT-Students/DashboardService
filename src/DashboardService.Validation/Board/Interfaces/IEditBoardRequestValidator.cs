using FluentValidation;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board;
using LT.DigitalOffice.Kernel.Attributes;

namespace LT.DigitalOffice.DashboardService.Validation.Board.Interfaces;

[AutoInject]
public interface IEditBoardRequestValidator : IValidator<PatchBoardRequest>
{
}
