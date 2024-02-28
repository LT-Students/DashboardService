using DigitalOffice.Models.Broker.Models.User;
using LT.DigitalOffice.DashboardService.Broker.Requests.Interfaces;
using LT.DigitalOffice.Kernel.BrokerSupport.Helpers;
using LT.DigitalOffice.Models.Broker.Common;
using LT.DigitalOffice.Models.Broker.Requests.User;
using LT.DigitalOffice.Models.Broker.Responses.User;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Broker.Requests;

public class UserService(
  IRequestClient<IGetUsersDataRequest> rcGetUsersData,
  IRequestClient<ICheckUsersExistence> rcCheckUsersExistence,
  ILogger<UserService> logger)
  : IUserService
{
  public async Task<List<Guid>> CheckUsersExistenceAsync(List<Guid> usersIds, List<string> errors = null)
  {
    return (await RequestHandler.ProcessRequest<ICheckUsersExistence, ICheckUsersExistence>(
      rcCheckUsersExistence,
      ICheckUsersExistence.CreateObj(userIds: usersIds),
      errors,
      logger))?.UserIds;
  }

  public async Task<List<UserData>> GetUsersDataAsync(
    List<Guid> usersIds,
    List<string> errors,
    CancellationToken cancellationToken)
  {
    if (usersIds is null || !usersIds.Any())
    {
      return null;
    }
    
    return (await rcGetUsersData.ProcessRequest<IGetUsersDataRequest, IGetUsersDataResponse>(
      IGetUsersDataRequest.CreateObj(usersIds),
      errors,
      logger, ct: cancellationToken))?.UsersData;
  }
}