﻿using LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.ChangeLog.Interfaces;

[AutoInject]
public interface IEditChangeLogCommand
{
  public Task<OperationResultResponse<bool>> ExecuteAsync(Guid id, JsonPatchDocument<EditChangeLogRequest> request);
}
