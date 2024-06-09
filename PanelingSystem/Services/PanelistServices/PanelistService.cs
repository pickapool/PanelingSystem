using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PanelingSystem.DatabaseContext;
using PanelingSystem.Models;

namespace PanelingSystem.Services.PanelistServices
{
    [Route("api/[controller]")]
    [ApiController]
    public class PanelistService : ControllerBase, IPanelistService
    {
        private readonly AppDBContext _context;

        public PanelistService(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/PanelistService
        [HttpGet]
        public async Task<IEnumerable<PanelistModel>> GetPanels()
        {
            return await _context.Panels.ToListAsync();
        }
        [HttpGet]
        public async Task<IEnumerable<PanelistModel>> GetPanelGroup(int groupId)
        {
            return await _context.Panels.Where( e => e.GroupId == groupId).Include( e => e.Panel).ToListAsync();
        }

        // GET: api/PanelistService/5
        [HttpGet("{id}")]
        public async Task<PanelistModel> GetPanelistModel(int id)
        {
            var panelistModel = await _context.Panels.FindAsync(id);

            if (panelistModel == null)
            {
                return null;
            }

            return panelistModel;
        }

        // PUT: api/PanelistService/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<PanelistModel> PutPanelistModel(int id, PanelistModel panelistModel)
        {
            if (id != panelistModel.PanelistId)
            {
                return null;
            }

            _context.Entry(panelistModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PanelistModelExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return panelistModel;
        }

        // POST: api/PanelistService
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<PanelistModel> PostPanelistModel(PanelistModel panelistModel)
        {
            _context.Panels.Add(panelistModel);
            _context.Entry(panelistModel).Reference(b => b.Panel).IsModified = false;
            await _context.SaveChangesAsync();

            return panelistModel;
        }

        // DELETE: api/PanelistService/5
        [HttpDelete("{id}")]
        public async Task<PanelistModel> DeletePanelistModel(int id)
        {
            var panelistModel = await _context.Panels.FindAsync(id);
            if (panelistModel == null)
            {
                return null;
            }

            _context.Panels.Remove(panelistModel);
            await _context.SaveChangesAsync();

            return panelistModel;
        }

        private bool PanelistModelExists(int id)
        {
            return _context.Panels.Any(e => e.PanelistId == id);
        }
    }
}
