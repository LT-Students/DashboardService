﻿using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board;
using LT.DigitalOffice.Kernel.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Board.Interfaces;

public interface IFindBoardsCommand
{
  public Task<OperationResultResponse<IEnumerable<BoardInfo>>> ExecuteAsync();
}