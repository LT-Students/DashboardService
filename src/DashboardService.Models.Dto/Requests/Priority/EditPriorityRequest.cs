using System;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority;

public record EditPriorityRequest
{
  public string Name { get; set; }
}