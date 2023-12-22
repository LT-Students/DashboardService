using LT.DigitalOffice.DashboardService.Mappers.Models.Interfaces;
using LT.DigitalOffice.DashboardService.Mappers.Responses.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;

namespace LT.DigitalOffice.DashboardService.Mappers.Responses;

public class ChangeLogResponseMapper : IChangeLogResponseMapper
{
  private readonly ITaskInfoMapper _taskInfoMapper;

  public ChangeLogResponseMapper(ITaskInfoMapper taskInfoMapper)
  {
    _taskInfoMapper = taskInfoMapper;
  }

  public ChangeLogResponse Map(DbChangeLog dbChangeLog)
  {
    return new()
    {
      Id = dbChangeLog.Id,
      CreatedBy = dbChangeLog.CreatedBy,
      EntityName = dbChangeLog.EntityName,
      PropertyName = dbChangeLog.PropertyName,
      PropertyOldValue = dbChangeLog.PropertyOldValue,
      PropertyNewValue = dbChangeLog.PropertyNewValue,
      CreatedAtUtc = dbChangeLog.CreatedAtUtc,
      Task = _taskInfoMapper.Map(dbChangeLog.Task)
    };
  }
}
