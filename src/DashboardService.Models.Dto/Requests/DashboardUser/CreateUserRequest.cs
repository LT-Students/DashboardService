using System;
using System.ComponentModel.DataAnnotations;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.DashboardUser;

public record CreateUserRequest
{
  /// <summary>
  /// User identifier.
  /// </summary>
  [Required]
  public Guid UserId { get; set; }
}