using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PanelingSystem.DatabaseContext;
using PanelingSystem.Models;

namespace PanelingSystem.Services.MemberServices
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberService : ControllerBase , IMemberService
    {
        private readonly AppDBContext _context;

        public MemberService(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/MemberService
        [HttpGet]
        public async Task<IEnumerable<MembersModel>> GetMembers()
        {
            return await _context.Members.ToListAsync();
        }
        [HttpGet]
        public async Task<IEnumerable<MembersModel>> GetMyGroupMembers(int groupId)
        {
            var groupMembers = await _context.Members
                .Include( e => e.Student)
                .Include(e => e.Group)
                .Where(member => member.GroupId == groupId)
                .ToListAsync();

            return groupMembers;
        }

        // GET: api/MemberService/5
        [HttpGet("{id}")]
        public async Task<MembersModel> GetMembersModel(int id)
        {
            var membersModel = await _context.Members.FindAsync(id);

            if (membersModel == null)
            {
                return null;
            }

            return membersModel;
        }

        // PUT: api/MemberService/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<MembersModel> PutMembersModel(int id, MembersModel membersModel)
        {
            if (id != membersModel.MemberId)
            {
                return null;
            }

            _context.Entry(membersModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembersModelExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return membersModel;
        }

        // POST: api/MemberService
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<MembersModel> PostMembersModel(MembersModel membersModel)
        {
            _context.Members.Add(membersModel);
            if(membersModel.Student != null)
            {
                _context.Entry(membersModel.Student).State = EntityState.Unchanged;
            }
            await _context.SaveChangesAsync();

            return membersModel;
        }

        // DELETE: api/MemberService/5
        [HttpDelete("{id}")]
        public async Task<MembersModel> DeleteMembersModel(int id)
        {
            var membersModel = await _context.Members.FindAsync(id);
            if (membersModel == null)
            {
                return null;
            }

            _context.Members.Remove(membersModel);
            await _context.SaveChangesAsync();

            return membersModel;
        }

        private bool MembersModelExists(int id)
        {
            return _context.Members.Any(e => e.MemberId == id);
        }
    }
}
