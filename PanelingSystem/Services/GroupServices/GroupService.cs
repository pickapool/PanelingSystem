using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PanelingSystem.DatabaseContext;
using PanelingSystem.Models;

namespace PanelingSystem.Services.GroupServices
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupService : ControllerBase, IGroupService
    {
        private readonly AppDBContext _context;

        public GroupService(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/GroupService
        [HttpGet]
        public async Task<IEnumerable<GroupModel>> GetGroups()
        {
            return await _context.Groups.ToListAsync();
        }
        [HttpGet]
        public async Task<IEnumerable<GroupModel>> GetGroupsWithUsers()
        {
            return await 
            _context
            .Groups
            .Include( e => e.Members)
            .ThenInclude( e => e.Student)
            .ToListAsync();;
        }
        [HttpGet]
        public async Task<IEnumerable<GroupModel>> GetGroupsWithUsers(FilterParameter param)
        {
            var query = _context.Groups
                        .Include(e => e.Members)
                        .ThenInclude(e => e.Student)
                        .AsQueryable();

            // Filter by Program if IsProgram is true
            if (param.IsProgram && !string.IsNullOrEmpty(param.ProgramName))
            {
                query = query.Where(e => e.Program == param.ProgramName);
            }

            // Filter by Section if IsSection is true
            if (param.IsSection && !string.IsNullOrEmpty(param.SectionName))
            {
                query = query.Where(e => e.Section == param.SectionName);
            }

            // Filter by Year if IsYear is true
            if (param.IsYear && !string.IsNullOrEmpty(param.Year))
            {
                query = query.Where(e => e.Year == param.Year);
            }

            return await query.ToListAsync();
        }
        [HttpGet]
        public async Task<IEnumerable<GroupModel>> GetMyGroups(int userId)
        {
            return await _context.Groups
                .Include(m => m.Members)
                .Where(group => group.Members.Any(member => member.UserId == userId))
                .ToListAsync();
        }
        [HttpGet]
        public async Task<IEnumerable<GroupModel>> GetMyGroups(int userId, FilterParameter param)
        {
            var query = _context.Groups
                        .Include(m => m.Members)
                        .AsQueryable();

            // Filter by Program if IsProgram is true
            if (param.IsProgram && !string.IsNullOrEmpty(param.ProgramName))
            {
                query = query.Where(group => group.Program == param.ProgramName);
            }

            // Filter by Section if IsSection is true
            if (param.IsSection && !string.IsNullOrEmpty(param.SectionName))
            {
                query = query.Where(group => group.Year == param.SectionName);
            }

            // Filter by Year if IsYear is true
            if (param.IsYear && !string.IsNullOrEmpty(param.Year))
            {
                query = query.Where(group => group.Year == param.Year);
            }

            // Filter by UserId in Members
            query = query.Where(group => group.Members.Any(member => member.UserId == userId));

            return await query.ToListAsync();
        }

        // GET: api/GroupService/5
        [HttpGet("{id}")]
        public async Task<GroupModel> GetGroupModel(int id)
        {
            var groupModel = await _context.Groups
            .Include( e => e.Members)
            .FirstOrDefaultAsync( e => e.GroupId == id);

            if (groupModel == null)
            {
                return null;
            }

            return groupModel;
        }

        // PUT: api/GroupService/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<GroupModel> PutGroupModel(int id, GroupModel groupModel)
        {
            if (id != groupModel.GroupId)
            {
                return null;
            }

            _context.Entry(groupModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupModelExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return groupModel;
        }

        // POST: api/GroupService
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<GroupModel> PostGroupModel(GroupModel groupModel)
        {
            _context.Groups.Add(groupModel);
            await _context.SaveChangesAsync();

            return groupModel;
        }

        // DELETE: api/GroupService/5
        [HttpDelete("{id}")]
        public async Task<GroupModel> DeleteGroupModel(int id)
        {
            var groupModel = await _context.Groups.FindAsync(id);
            if (groupModel == null)
            {
                return null;
            }

            _context.Groups.Remove(groupModel);
            await _context.SaveChangesAsync();

            return groupModel;
        }

        private bool GroupModelExists(int id)
        {
            return _context.Groups.Any(e => e.GroupId == id);
        }
    }
}
