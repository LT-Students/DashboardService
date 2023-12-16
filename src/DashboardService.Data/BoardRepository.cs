using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Provider;
using LT.DigitalOffice.DashboardService.Models.Db;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Data;

public class BoardRepository : IBoardRepository
{
  private readonly IDataProvider _provider;

  public BoardRepository([FromServices] IDataProvider provider)
  {
    _provider = provider;
  }

  public Task CreateAsync(DbBoard board)
  {
    throw new NotImplementedException();
  }

  public Task<bool> EditAsync(Guid id)
  {
    throw new NotImplementedException();
  }

  public Task<DbBoard> GetAsync(Guid id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<DbBoard>> GetAllAsync()
  {
    throw new NotImplementedException();
  }

  public Task<bool> RemoveAsync(Guid id)
  {
    throw new NotImplementedException();
  }
}
