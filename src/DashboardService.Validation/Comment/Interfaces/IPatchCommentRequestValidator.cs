using FluentValidation;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Comment;

namespace LT.DigitalOffice.DashboardService.Validation.Comment.Interfaces;

public interface IPatchCommentRequestValidator : IValidator<PatchCommentRequest> { }