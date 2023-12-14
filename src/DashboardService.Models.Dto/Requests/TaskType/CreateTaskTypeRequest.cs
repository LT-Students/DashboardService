namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.TaskType;

public record CreateTaskTypeRequest
{
  public string TaskTypeName { get; set; }
}