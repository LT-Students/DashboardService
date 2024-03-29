﻿using LT.DigitalOffice.DashboardService.Business.Board.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Mappers.Models.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board.Filters;
using LT.DigitalOffice.Kernel.Responses;
using System.Threading;
using System.Threading.Tasks;
using LT.DigitalOffice.DashboardService.Models.Db;
using System.Collections.Generic;

namespace LT.DigitalOffice.DashboardService.Business.Board;

public class GetBoardsCommand : IGetBoardsCommand
{
  private readonly IBoardRepository _boardRepository;
  private readonly IBoardInfoMapper _boardInfoMapper;

  public GetBoardsCommand(
    IBoardRepository repository,
    IBoardInfoMapper boardInfoMapper)
  {
    _boardRepository = repository;
    _boardInfoMapper = boardInfoMapper;
  }

  public async Task<FindResultResponse<BoardInfo>> ExecuteAsync(GetBoardsFilter filter, CancellationToken ct)
  {
    (List<DbBoard> boards, int totalCount) = await _boardRepository.GetAllAsync(filter, ct);

    return new()
    {
      Body = boards.ConvertAll(_boardInfoMapper.Map),
      TotalCount = totalCount
    };
  }
}
