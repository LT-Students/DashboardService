using System;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority;

public record EditPriorityRequest
{
  /// <summary>
  /// New priority name.
  /// </summary>
  public string Name { get; set; }
}