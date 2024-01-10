using LT.DigitalOffice.DashboardService.Business.Board.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board;
using LT.DigitalOffice.Kernel.Responses;
using System.Threading.Tasks;
using System;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Mappers.Db.Interfaces;
using LT.DigitalOffice.DashboardService.Validation.Board.Interfaces;
using Microsoft.AspNetCore.Http;
using LT.DigitalOffice.Kernel.BrokerSupport.AccessValidatorEngine.Interfaces;
using LT.DigitalOffice.Kernel.Helpers.Interfaces;
using System.Threading;
using System.Net;
using FluentValidation.Results;
using System.Linq;
using LT.DigitalOffice.Kernel.Extensions;
using LT.DigitalOffice.DashboardService.Models.Db;

namespace LT.DigitalOffice.DashboardService.Business.Board;

public class CreateBoardCommand : ICreateBoardCommand
{
  private readonly IBoardRepository _boardRepository;
  private readonly IDbBoardMapper _dbBoardMapper;
  private readonly IHttpContextAccessor _httpContextAccessor;
  private readonly IAccessValidator _accessValidator;
  private readonly IResponseCreator _responseCreator;
  private readonly ICreateBoardRequestValidator _validator;

  public CreateBoardCommand(
    IBoardRepository repository,
    IDbBoardMapper dbBoardMapper,
    IHttpContextAccessor httpContext,
    IAccessValidator accessValidator,
    IResponseCreator responseCreator,
    ICreateBoardRequestValidator validator)
  {
    _boardRepository = repository;
    _dbBoardMapper = dbBoardMapper;
    _httpContextAccessor = httpContext;
    _accessValidator = accessValidator;
    _responseCreator = responseCreator;
    _validator = validator;
  }

  public async Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateBoardRequest request, CancellationToken ct)
  {
    Guid userId = _httpContextAccessor.HttpContext.GetUserId();

    if (!await _accessValidator.IsAdminAsync(userId))
    {
      return _responseCreator.CreateFailureResponse<Guid?>(HttpStatusCode.Forbidden);
    }

    ValidationResult validationResult = await _validator.ValidateAsync(request, ct);

    if (!validationResult.IsValid)
    {
      return _responseCreator.CreateFailureResponse<Guid?>(
        HttpStatusCode.BadRequest,
        validationResult.Errors.ConvertAll(vf => vf.ErrorMessage));
    }

    _httpContextAccessor.HttpContext.Response.StatusCode = (int)HttpStatusCode.Created;

    DbBoard dbBoard = _dbBoardMapper.Map(request, userId);

    return new()
    {
      Body = await _boardRepository.CreateAsync(dbBoard)
    };
  }
}

