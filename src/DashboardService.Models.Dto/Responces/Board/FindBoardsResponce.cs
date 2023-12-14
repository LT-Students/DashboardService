using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using System.Collections.Generic;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Responces.Board;
public class FindBoardsResponce
{
  public IEnumerable<BoardInfo> Boards { get; set; }
}
