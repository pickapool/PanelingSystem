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
        public async Task<IEnumerable<GroupModel>> GetMyGroups(int userId)
        {
            return await _context.Groups
                .Include(m => m.Members)
                .Where(group => group.Members.Any(member => member.UserId == userId))
                .ToListAsync();
        }

        // GET: api/GroupService/5
        [HttpGet("{id}")]
        public async Task<GroupModel> GetGroupModel(int id)
        {
            var groupModel = await _context.Groups.FindAsync(id);

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
