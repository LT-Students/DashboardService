using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Comment.Filters;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Data;

public class CommentRepository : ICommentRepository
{
  public Task<Guid?> CreateAsync(DbComment dbComment)
  {
    throw new NotImplementedException();
  }

  public Task<DbComment> GetAllAsync(GetCommentsFilter filter)
  {
    throw new NotImplementedException();
  }

  public Task<DbComment> GetAsync(Guid id, GetCommentFilter filter)
  {
    throw new NotImplementedException();
  }

  public Task<bool> EditAsync(Guid id, JsonPatchDocument<DbComment> request)
  {
    throw new NotImplementedException();
  }

  public Task<bool> RemoveAsync(Guid id)
  {
    throw new NotImplementedException();
  }
}