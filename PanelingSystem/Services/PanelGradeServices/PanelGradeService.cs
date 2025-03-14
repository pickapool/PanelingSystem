using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;
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

        public async Task<PanelGradeModel> GetPanelGrade(int accountId, int memberId, Enums.FilePosition pos)
        {
            var get = await _context.PanelGrades.Include(e => e.UserAccount).FirstOrDefaultAsync(e => e.UserId == accountId && e.MemberId == memberId && e.DefenseType == pos);
            if(get == null) {
                get = new();
                get.DefenseType = pos;
            }
            return get;
        }

        public async Task<IEnumerable<PanelGradeModel>> GetPanelGrades()
        {
            return await _context.PanelGrades.ToListAsync();
        }
        public async Task<List<PanelGradeModel>> GetMemeberGrades(int memberId, Enums.FilePosition defenseType)
        {
            return await _context.PanelGrades.Include( e => e.UserAccount).Where( e => e.MemberId == memberId && e.DefenseType == defenseType).ToListAsync();
        }


        public async Task<PanelGradeModel> PostPanelGrade(PanelGradeModel PanelGradeModel)
        {
            _context.PanelGrades.Add(PanelGradeModel);
            await _context.SaveChangesAsync();

            return PanelGradeModel;
        }

        public async Task<PanelGradeModel> PutPanelGrade(int id, PanelGradeModel panelGradeModel)
        {
             var existingPanelGrade = await _context.PanelGrades
                .FirstOrDefaultAsync(pg => pg.DefenseType == panelGradeModel.DefenseType && pg.MemberId == panelGradeModel.MemberId);

            if (existingPanelGrade == null)
            {
                panelGradeModel.PanelGradeId = 0; 
                _context.PanelGrades.Add(panelGradeModel);  
                await _context.SaveChangesAsync();
                return panelGradeModel;
            }
            else
            {
                //_context.Entry(panelGradeModel.UserAccount).State = State.Unc;
                _context.Entry(panelGradeModel).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return panelGradeModel;
            }
        }
        private bool PanelModelExists(int id)
        {
            return _context.PanelGrades.Any(e => e.PanelGradeId == id);
        }
    }
}
