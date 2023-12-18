using System;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Responses;

public class BoardResponse
{
  public Guid Id { get; set; }

  public Guid ProjectId { get; set; }

  public string Name { get; set; }

  public bool IsActive { get; set; }

  /* public GroupInfo Group {get; set;} */
}
