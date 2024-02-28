using DigitalOffice.Models.Broker.Models.User;
using LT.DigitalOffice.DashboardService.Broker.Requests.Interfaces;
using LT.DigitalOffice.DashboardService.Business.Board.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Mappers.Responses.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board.Filters;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using LT.DigitalOffice.Kernel.Helpers.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Board;

public class GetBoardCommand(
  IBoardRepository repository,
  IBoardResponseMapper boardResponseMapper,
  IResponseCreator responseCreator,
  IUserService userService)
  : IGetBoardCommand
{
  public async Task<OperationResultResponse<BoardResponse>> ExecuteAsync(Guid id, GetBoardFilter filter, CancellationToken ct)
  {
    DbBoard dbBoard = await repository.GetAsync(id, filter, ct);

    if (dbBoard is null)
    {
      return responseCreator.CreateFailureResponse<BoardResponse>(HttpStatusCode.NotFound);
    }

    List<UserData> usersData = await userService.GetUsersDataAsync(
      dbBoard.Users.Select(u => u.Id).ToList(),
      null,
      ct);
    
    return new OperationResultResponse<BoardResponse>(
      body: boardResponseMapper.Map(dbBoard, usersData)); // надо userData отдавать или просто ids`ки?
  }
}
