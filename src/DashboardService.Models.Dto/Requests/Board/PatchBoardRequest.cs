using System;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board;

public class PatchBoardRequest
{
  public Guid Id { get; set; }

  public Guid ProjectId { get; set; }

  public string Name { get; set; }

  public bool IsActive { get; set; }

  public Guid ModifiedBy { get; set; }

  public DateTime ModifiedAtUtc { get; set; }
}
