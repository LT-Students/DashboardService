using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Provider;
using LT.DigitalOffice.DashboardService.Models.Db;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Data;

public class DashboardUserRepository(
  IDataProvider provider,
  IHttpContextAccessor httpContextAccessor) : IDashboardUserRepository
{
  public async Task<bool> CreateAsync(List<DbDashboardUser> dasbhoardUsers)
  {
    provider.DashboardUsers.AddRange(dasbhoardUsers);
    await provider.SaveAsync();

    return true;
  }
}