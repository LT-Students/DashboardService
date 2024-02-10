using System.ComponentModel.DataAnnotations;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.TaskType;

public record CreateTaskTypeRequest
{
  /// <summary>
  /// Task type name.
  /// </summary>
  [Required]
  public string Name { get; set; }
}