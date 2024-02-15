namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.TaskType;

public record EditTaskTypeRequest
{
  /// <summary>
  /// New task type name.
  /// </summary>
  public string Name { get; set; }
}