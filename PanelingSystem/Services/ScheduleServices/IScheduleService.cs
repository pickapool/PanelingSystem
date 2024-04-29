using PanelingSystem.Models;

namespace PanelingSystem.Services.ScheduleServices
{
    public interface IScheduleService
    {
        Task<IEnumerable<ScheduleModel>> GetSchedules();
        Task<ScheduleModel> GetScheduleModel(int id);
        Task<ScheduleModel> PutScheduleModel(int id, ScheduleModel scheduleModel);
        Task<ScheduleModel> PostScheduleModel(ScheduleModel scheduleModel);
        Task<ScheduleModel> DeleteScheduleModel(int id);
        Task<ScheduleModel> GetPanelsInSchedule(int groupId);
    }
}
