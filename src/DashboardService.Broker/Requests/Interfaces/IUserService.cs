using DigitalOffice.Models.Broker.Models.User;
using LT.DigitalOffice.Kernel.Attributes;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Broker.Requests.Interfaces;

[AutoInject]
public interface IUserService
{
  Task<List<Guid>> CheckUsersExistenceAsync(
    List<Guid> usersIds,
    List<string> errors = null);
  
  Task<List<UserData>> GetUsersDataAsync(
    List<Guid> usersIds,
    List<string> errors,
    CancellationToken cancellationToken);
}