using FluentValidation;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board;
using LT.DigitalOffice.DashboardService.Validation.Board.Interfaces;

namespace LT.DigitalOffice.DashboardService.Validation.Board;

public class CreateBoardRequestValidator : AbstractValidator<CreateBoardRequest>, ICreateBoardRequestValidator
{
  public CreateBoardRequestValidator(IBoardRepository boardRepository)
  {
    RuleFor(request => request.ProjectId)
      .NotEmpty()
      .WithMessage("Project id can not be empty.");

    RuleFor(request => request.Name)
      .NotEmpty()
      .WithMessage("Board name can not be empty.");

    RuleFor(request => request.Name)
      .MaximumLength(50)
      .WithMessage("Board name is too long.")
      .MustAsync(async (request, name, ct) => !await boardRepository.NameExistAsync(name, request.ProjectId, ct))
      .WithMessage("Board with this name already exists.");
  }
}
