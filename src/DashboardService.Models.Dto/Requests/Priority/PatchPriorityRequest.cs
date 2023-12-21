using System;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority;

public record PatchPriorityRequest
{
  public string Name { get; set; }
}