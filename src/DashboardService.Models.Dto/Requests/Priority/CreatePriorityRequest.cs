using System.ComponentModel.DataAnnotations;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority;

public record CreatePriorityRequest
{
  [Required]
  public string Name { get; set; }
}