﻿using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Group.Filters;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Group.Interfaces;

[AutoInject]
public interface IGetGroupCommand
{
  Task<OperationResultResponse<GroupResponse>> ExecuteAsync(GetGroupFilter filter, Guid id);
}