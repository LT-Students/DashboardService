namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.TaskType;

public record PatchTaskTypeRequest
{
  public string TaskTypeName { get; set; }
}