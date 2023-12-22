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

namespace LT.DigitalOffice.DashboardService.Business.Board;

public class EditBoardCommand : IEditBoardCommand
{
  private readonly IBoardRepository _boardRepository;
  private readonly IPatchDbBoardMapper _patchDbBoardMapper;
  private readonly IHttpContextAccessor _httpContext;
  private readonly IAccessValidator _accessValidator;
  private readonly IResponseCreator _responseCreator;


  public EditBoardCommand(
    IBoardRepository repository,
    IPatchDbBoardMapper _patchMapper,
    IHttpContextAccessor httpContextAccessor,
    IAccessValidator accessValidator,
    IResponseCreator responseCreator)
  {
    _boardRepository = repository;
    _patchDbBoardMapper = _patchMapper;
    _httpContext = httpContextAccessor;
    _accessValidator = accessValidator;
    _responseCreator = responseCreator;
  }

  public Task<OperationResultResponse<bool>> ExecuteAsync(Guid id, JsonPatchDocument<PatchBoardRequest> request)
  {
    throw new NotImplementedException();
  }
}
