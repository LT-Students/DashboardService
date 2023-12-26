using System;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Models;

public class BoardInfo
{
  public Guid Id { get; set; }

  public Guid ProjectId { get; set; }

  public string Name { get; set; }

  public bool IsActive { get; set; }

  /* public GroupInfo Group {get; set;} */
}

