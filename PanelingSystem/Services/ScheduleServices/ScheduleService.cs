using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PanelingSystem.DatabaseContext;
using PanelingSystem.Models;

namespace PanelingSystem.Services.ScheduleServices
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleService : ControllerBase, IScheduleService
    {
        private readonly AppDBContext _context;

        public ScheduleService(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/ScheduleService
        [HttpGet]
        public async Task<IEnumerable<ScheduleModel>> GetSchedules()
        {
            return await _context.Schedules
            .Include( e => e.Panels)
            .ThenInclude( e => e.Panel)
            .ToListAsync();
        }
        [HttpGet]
        public async Task<List<ScheduleModel>> GetSchedulesByGroup(int groupId)
        {
            return await _context.Schedules.Where( e => e.GroupId == groupId)
            .ToListAsync();
        }
        [HttpGet]
        public async Task<IEnumerable<ScheduleModel>> GetSchedules(FilterParameter param)
        {
            var query = _context.Schedules
            .Include( e => e.Group)
            .Include( e => e.Panels)
            .ThenInclude( e => e.Panel).AsQueryable();

            // Apply filters based on the FilterParameter values

            if (param.IsProgram && !string.IsNullOrEmpty(param.ProgramName))
            {
                query = query.Where(e => e.Group.Program == param.ProgramName);
            }

            if (param.IsSection && !string.IsNullOrEmpty(param.SectionName))
            {
                query = query.Where(e => e.Group.Section == param.SectionName);
            }

            if (param.IsYear && !string.IsNullOrEmpty(param.Year))
            {
                query = query.Where(e => e.Group.Year == param.Year);
            }

            // Execute and return the filtered list of schedules
            return await query.ToListAsync();
        }
        public async Task<ScheduleModel> GetPanelsInSchedule(int groupId)
        {
            return await 
            _context
            .Schedules
            .Where(s => s.GroupId == groupId)
            .Include( e => e.Panels)
            .ThenInclude( e => e.Panel)
            .FirstOrDefaultAsync() ?? new();
        }
        // GET: api/ScheduleService/5
        [HttpGet("{id}")]
        public async Task<ScheduleModel> GetScheduleModel(int id)
        {
            var scheduleModel = await _context.Schedules.FindAsync(id);

            if (scheduleModel == null)
            {
                return null;
            }

            return scheduleModel;
        }

        // PUT: api/ScheduleService/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ScheduleModel> PutScheduleModel(int id, ScheduleModel scheduleModel)
        {
            if (id != scheduleModel.ScheduleId)
            {
                return null;
            }

            _context.Entry(scheduleModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScheduleModelExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return scheduleModel;
        }

        // POST: api/ScheduleService
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ScheduleModel> PostScheduleModel(ScheduleModel scheduleModel)
        {
            _context.Schedules.Add(scheduleModel);
            await _context.SaveChangesAsync();

            return scheduleModel;
        }

        // DELETE: api/ScheduleService/5
        [HttpDelete("{id}")]
        public async Task<ScheduleModel> DeleteScheduleModel(int id)
        {
            var scheduleModel = await _context.Schedules.FindAsync(id);
            if (scheduleModel == null)
            {
                return null;
            }

            _context.Schedules.Remove(scheduleModel);
            await _context.SaveChangesAsync();

            return scheduleModel;
        }

        private bool ScheduleModelExists(int id)
        {
            return _context.Schedules.Any(e => e.ScheduleId == id);
        }
    }
}
