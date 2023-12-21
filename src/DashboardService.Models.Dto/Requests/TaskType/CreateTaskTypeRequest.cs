using System.ComponentModel.DataAnnotations;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.TaskType;

public record CreateTaskTypeRequest
{
  [Required]
  public string Name { get; set; }
}