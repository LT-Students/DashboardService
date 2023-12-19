using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Data;

public class GroupRepository : IGroupRepository
{
  public Task<Guid?> CreateAsync(DbGroup dbDepartment)
  {
    throw new NotImplementedException();
  }

  public Task<DbGroup> GetAllAsync()
  {
    throw new NotImplementedException();
  }

  public Task<DbGroup> GetAsync(Guid id)
  {
    throw new NotImplementedException();
  }

  public Task<bool> EditAsync(Guid id)
  {
    throw new NotImplementedException();
  }

  public Task<bool> RemoveAsync(Guid id)
  {
    throw new NotImplementedException();
  }
}