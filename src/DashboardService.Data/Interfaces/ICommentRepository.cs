using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Comment.Filters;
using LT.DigitalOffice.Kernel.Attributes;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Data.Interfaces;

[AutoInject]
public interface ICommentRepository
{
  Task<Guid?> CreateAsync(DbComment dbDepartment);
  Task<DbComment> GetAllAsync(GetCommentsFilter filter);
  Task<DbComment> GetAsync(Guid id, GetCommentFilter filter);
  Task<bool> EditAsync(Guid id, JsonPatchDocument<DbComment> request);
  Task<bool> RemoveAsync(Guid id);
}