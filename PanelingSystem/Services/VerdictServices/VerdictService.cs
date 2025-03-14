using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PanelingSystem.DatabaseContext;
using PanelingSystem.Models;
using PanelingSystem.Services.GradeServices;

namespace PanelingSystem.Services.DefenseVerdictServices
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerdictService : ControllerBase, IVerdictService
    {
        private readonly AppDBContext _context;

        public VerdictService(AppDBContext context)
        {
            _context = context;
        }
        [HttpGet]


        //
        [HttpPut("{id}")]
        public async Task<DefenseVerdictModel> PutDefenseVerdictModel(int id, DefenseVerdictModel DefenseVerdictModel)
        {
            if (id != DefenseVerdictModel.DefenseVerdictId)
            {
                return null;
            }
            _context.Entry(DefenseVerdictModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DefenseVerdictModelExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return DefenseVerdictModel;
        }

        // POST: api/DefenseVerdictService
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<DefenseVerdictModel> PostDefenseVerdictModel(DefenseVerdictModel DefenseVerdictModel)
        {
            _context.DefenseVerdicts.Add(DefenseVerdictModel);
            await _context.SaveChangesAsync();

            return DefenseVerdictModel;
        }

        // DELETE: api/DefenseVerdictService/5
        [HttpDelete("{id}")]
        public async Task<DefenseVerdictModel> DeleteDefenseVerdictModel(int id)
        {
            var DefenseVerdictModel = await _context.DefenseVerdicts.FindAsync(id);
            if (DefenseVerdictModel == null)
            {
                return null;
            }

            _context.DefenseVerdicts.Remove(DefenseVerdictModel);
            await _context.SaveChangesAsync();

            return DefenseVerdictModel;
        }

        private bool DefenseVerdictModelExists(int id)
        {
            return _context.DefenseVerdicts.Any(e => e.DefenseVerdictId == id);
        }

        bool IVerdictService.DefenseVerdictModelExists(int id)
        {
            return _context.DefenseVerdicts.Any(e => e.DefenseVerdictId == id);
        }

        public async Task<List<DefenseVerdictModel>> GetDefenseVerdictModel()
        {
            return await _context.DefenseVerdicts.Include( e => e.Group).ToListAsync();
        }

        public async Task<DefenseVerdictModel> GetVerdict(long GroupId, Enums.Chapter chapter)
        {
            return await _context.DefenseVerdicts.Where( e => e.GroupId == GroupId && e.Chapter == chapter).FirstOrDefaultAsync()?? new();
        }
    }
}
