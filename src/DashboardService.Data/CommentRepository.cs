using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Data;

public class CommentRepository : ICommentRepository
{
  public Task<Guid?> CreateAsync(DbComment dbDepartment)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<DbComment>> GetAllAsync()
  {
    throw new NotImplementedException();
  }

  public Task<DbComment> GetAsync(Guid id)
  {
    throw new NotImplementedException();
  }

  public Task<bool> EditAsync(Guid id)
  {
    throw new NotImplementedException();
  }

  public Task<bool> DeleteAsync(Guid id)
  {
    throw new NotImplementedException();
  }
}