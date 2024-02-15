using System;
using System.ComponentModel.DataAnnotations;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board;

public class CreateBoardRequest
{
  /// <summary>
  /// Unique project identifier.
  /// </summary>
  [Required]
  public Guid ProjectId { get; set; }

  /// <summary>
  /// Board name.
  /// </summary>
  [Required]
  public string Name { get; set; }
}
