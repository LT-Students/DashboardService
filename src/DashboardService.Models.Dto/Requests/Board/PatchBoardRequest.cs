namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board;

public class PatchBoardRequest
{
  /// <summary>
  /// New board name.
  /// </summary>
  public string Name { get; set; }

  /// <summary>
  /// New board activity.
  /// </summary>
  public bool IsActive { get; set; }
}
