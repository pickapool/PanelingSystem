using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PanelingSystem.DatabaseContext;
using PanelingSystem.Models;

namespace PanelingSystem.Services.PanelGradeServices
{
    public class PanelGradeService : ControllerBase, IPanelGradeService
    {
        private readonly AppDBContext _context;

        public PanelGradeService(AppDBContext context)
        {
            _context = context;
        }
        public async Task<PanelGradeModel> DeletePanelGrade(int id)
        {
            var membersModel = await _context.PanelGrades.FindAsync(id);
            if (membersModel == null)
            {
                return null;
            }

            _context.PanelGrades.Remove(membersModel);
            await _context.SaveChangesAsync();

            return membersModel;
        }

        public async Task<PanelGradeModel> GetPanelGrade(int accountId, int memberId)
        {
            return await _context.PanelGrades.Include(e => e.UserAccount).FirstOrDefaultAsync(e => e.UserId == accountId && e.MemberId == memberId) ?? new();
        }

        public async Task<IEnumerable<PanelGradeModel>> GetPanelGrades()
        {
            return await _context.PanelGrades.ToListAsync();
        }

        public async Task<PanelGradeModel> PostPanelGrade(PanelGradeModel PanelGradeModel)
        {
            _context.PanelGrades.Add(PanelGradeModel);
            await _context.SaveChangesAsync();

            return PanelGradeModel;
        }

        public async Task<PanelGradeModel> PutPanelGrade(int id, PanelGradeModel PanelGradeModel)
        {
            if (id != PanelGradeModel.PanelGradeId)
            {
                return null;
            }

            _context.Entry(PanelGradeModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PanelModelExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return PanelGradeModel;
        }
        private bool PanelModelExists(int id)
        {
            return _context.PanelGrades.Any(e => e.PanelGradeId == id);
        }
    }
}
