using LT.DigitalOffice.DashboardService.Mappers.Models.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;

namespace LT.DigitalOffice.DashboardService.Mappers.Models;

public class ChangeLogInfoMapper : IChangeLogInfoMapper
{
  //private readonly ITaskInfoMapper _taskInfoMapper;

  public ChangeLogInfoMapper(/*ITaskInfoMapper taskInfoMapper*/)
  {
    //_taskInfoMapper = taskInfoMapper;
  }

  public ChangeLogInfo Map(DbChangeLog dbChangeLog)
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
      // Task = _taskInfoMapper.Map(dbChangeLog.Task);
    };
  }
}
