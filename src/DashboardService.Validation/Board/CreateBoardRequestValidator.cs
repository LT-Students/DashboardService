using FluentValidation;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board;
using LT.DigitalOffice.DashboardService.Validation.Board.Interfaces;

namespace LT.DigitalOffice.DashboardService.Validation.Board;

public class CreateBoardRequestValidator : AbstractValidator<CreateBoardRequest>, ICreateBoardRequestValidator
{
  public CreateBoardRequestValidator(IBoardRepository boardRepository)
  {
  }
}
