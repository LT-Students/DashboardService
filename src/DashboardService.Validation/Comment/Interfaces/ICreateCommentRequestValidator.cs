using FluentValidation;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Comment;
using LT.DigitalOffice.Kernel.Attributes;

namespace LT.DigitalOffice.DashboardService.Validation.Comment.Interfaces;

[AutoInject]
public interface ICreateCommentRequestValidator : IValidator<CreateCommentRequest> { }