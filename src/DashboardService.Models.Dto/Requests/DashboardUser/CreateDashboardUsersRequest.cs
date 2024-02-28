using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.DashboardUser;

public record CreateDashboardUsersRequest
{
  /// <summary>
  /// Dashboard identifier.
  /// </summary>
  [Required]
  public Guid DashboardId { get; set; }
    
  [Required]
  public List<CreateUserRequest> Users { get; set; }
}