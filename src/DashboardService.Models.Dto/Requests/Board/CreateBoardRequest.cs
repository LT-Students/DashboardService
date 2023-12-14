using System;
using System.ComponentModel.DataAnnotations;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board;

public record class CreateBoardRequest
{
  [Required]
  public Guid ProjectId { get; set; }

  [Required]
  public string Name { get; set; }

  [Required]
  public Guid CreatedBy { get; set; }
}
