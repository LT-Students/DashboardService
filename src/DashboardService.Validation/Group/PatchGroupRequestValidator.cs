﻿using FluentValidation;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Group;
using LT.DigitalOffice.DashboardService.Validation.Group.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LT.DigitalOffice.DashboardService.Validation.Group;

public class PatchGroupRequestValidator : AbstractValidator<EditGroupRequest>, IPatchGroupRequestValidator
{
  public PatchGroupRequestValidator(IGroupRepository repository)
  {
  }
}