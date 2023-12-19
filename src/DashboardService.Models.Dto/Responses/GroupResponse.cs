using System;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Responses;

public record GroupResponse
{
  public Guid GroupId { get; set; }
  public Guid BoardId { get; set; }
  public string GroupName { get; set; }
  public bool GroupIsActive { get; set; }
  public Guid GroupCreatedBy { get; set; }
  public DateTime GroupCreatedAtUtc { get; set; }
  public Guid? GroupModifiedBy { get; set; }
  public DateTime? GroupModifiedAtUtc { get; set; }
}