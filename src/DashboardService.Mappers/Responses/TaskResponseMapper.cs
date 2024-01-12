using LT.DigitalOffice.DashboardService.Mappers.Models;
using LT.DigitalOffice.DashboardService.Mappers.Models.Interfaces;
using LT.DigitalOffice.DashboardService.Mappers.Responses.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;

namespace LT.DigitalOffice.DashboardService.Mappers.Responses;

public class TaskResponseMapper : ITaskResponseMapper
{
  private readonly IGroupInfoMapper _groupInfoMapper;
  private readonly ITaskTypeInfoMapper _taskTypeInfoMapper;
  private readonly IPriorityInfoMapper _priorityInfoMapper;
  private readonly ICommentInfoMapper _commentInfoMapper;
  private readonly IChangeLogInfoMapper _changeLogInfoMapper;

  public TaskResponseMapper(
    IGroupInfoMapper groupInfoMapper,
    ITaskTypeInfoMapper taskTypeInfoMapper,
    IPriorityInfoMapper priorityInfoMapper,
    ICommentInfoMapper commentInfoMapper,
    IChangeLogInfoMapper changeLogInfoMapper)
  {
    _groupInfoMapper = groupInfoMapper;
    _taskTypeInfoMapper = taskTypeInfoMapper;
    _priorityInfoMapper = priorityInfoMapper;
    _commentInfoMapper = commentInfoMapper;
    _changeLogInfoMapper = changeLogInfoMapper;
  }
  
  public TaskResponse Map(DbTask dbTask)
  {
    return new()
    {
      Id = dbTask.Id,
      GroupId = dbTask.GroupId,
      TaskTypeId = dbTask.TaskTypeId,
      PriorityId = dbTask.PriorityId,
      Name = dbTask.Name,
      Content = dbTask.Content,
      CreatedAtUtc = dbTask.CreatedAtUtc,
      DeadlineAtUtc = dbTask.DeadlineAtUtc,
      
      TaskType = _taskTypeInfoMapper.Map(dbTask.TaskType),
      Priority = _priorityInfoMapper.Map(dbTask.Priority),
      Comments = dbTask.Comments.ConvertAll(_commentInfoMapper.Map),
      Logs = dbTask.Logs.ConvertAll(_changeLogInfoMapper.Map)
    };
  }
}