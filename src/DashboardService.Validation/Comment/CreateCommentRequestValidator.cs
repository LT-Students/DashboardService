using FluentValidation;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Comment;
using LT.DigitalOffice.DashboardService.Validation.Comment.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LT.DigitalOffice.DashboardService.Validation.Comment;

public class CreateCommentRequestValidator : AbstractValidator<CreateCommentRequest>, ICreateCommentRequestValidator
{
  public CreateCommentRequestValidator(ICommentRepository reposisoty)
  {
  }
}