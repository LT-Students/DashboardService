using LT.DigitalOffice.DashboardService.Business.Board.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board;
using LT.DigitalOffice.Kernel.Responses;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.JsonPatch;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Mappers.Db.Interfaces;
using Microsoft.AspNetCore.Http;
using LT.DigitalOffice.Kernel.BrokerSupport.AccessValidatorEngine.Interfaces;
using LT.DigitalOffice.Kernel.Helpers.Interfaces;
using System.Threading;
using System.Net;
using LT.DigitalOffice.DashboardService.Validation.Board.Interfaces;
using FluentValidation.Results;
using System.Linq;
using LT.DigitalOffice.Kernel.Extensions;

namespace LT.DigitalOffice.DashboardService.Business.Board;

public class EditBoardCommand : IEditBoardCommand
{
  private readonly IBoardRepository _boardRepository;
  private readonly IPatchDbBoardMapper _patchDbBoardMapper;
  private readonly IHttpContextAccessor _httpContext;
  private readonly IAccessValidator _accessValidator;
  private readonly IResponseCreator _responseCreator;
  private readonly IEditBoardRequestValidator _validator;

  public EditBoardCommand(
    IBoardRepository repository,
    IPatchDbBoardMapper _patchMapper,
    IHttpContextAccessor httpContextAccessor,
    IAccessValidator accessValidator,
    IResponseCreator responseCreator,
    IEditBoardRequestValidator validator)
  {
    _boardRepository = repository;
    _patchDbBoardMapper = _patchMapper;
    _httpContext = httpContextAccessor;
    _accessValidator = accessValidator;
    _responseCreator = responseCreator;
    _validator = validator;
  }

  public async Task<OperationResultResponse<bool>> ExecuteAsync(
    Guid boardId,
    JsonPatchDocument<PatchBoardRequest> request,
    CancellationToken ct)
  {
    Guid userId = _httpContext.HttpContext.GetUserId();

    if (!await _accessValidator.IsAdminAsync(userId))
    {
      return _responseCreator.CreateFailureResponse<bool>(HttpStatusCode.Forbidden);
    }

    ValidationResult validationResult = await _validator.ValidateAsync((boardId, request), ct);

    if (!validationResult.IsValid)
    {
      return _responseCreator.CreateFailureResponse<bool>(
        HttpStatusCode.BadRequest,
        validationResult.Errors.ConvertAll(vf => vf.ErrorMessage));
    }

    return new OperationResultResponse<bool>(
      body: await _boardRepository.EditByIdAsync(boardId, userId, _patchDbBoardMapper.Map(request), ct));
  }
}
