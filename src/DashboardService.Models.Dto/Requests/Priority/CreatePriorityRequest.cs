using System.ComponentModel.DataAnnotations;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority;

public record CreatePriorityRequest
{
  /// <summary>
  /// Priority name.
  /// </summary>
  [Required]
  public string Name { get; set; }
}