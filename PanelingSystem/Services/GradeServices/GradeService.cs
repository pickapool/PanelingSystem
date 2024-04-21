using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PanelingSystem.DatabaseContext;
using PanelingSystem.Models;

namespace PanelingSystem.Services.GradeServices
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeService : ControllerBase, IGradeService
    {
        private readonly AppDBContext _context;

        public GradeService(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/GradeService
        [HttpGet]
        public async Task<IEnumerable<GradeModel>> GetGradeModel()
        {
            return await _context.Grades.ToListAsync();
        }
        [HttpGet]
        public async Task<GradeModel> GetStudentGrade( int userId)
        {
            return await _context.Grades.FirstOrDefaultAsync( e => e.UserId == userId);
        }

        // GET: api/GradeService/5
        [HttpGet("{id}")]
        public async Task<GradeModel> GetGradeModel(int id)
        {
            var gradeModel = await _context.Grades.FindAsync(id);

            if (gradeModel == null)
            {
                return null;
            }

            return gradeModel;
        }

        // PUT: api/GradeService/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<GradeModel> PutGradeModel(int id, GradeModel gradeModel)
        {
            if (id != gradeModel.GradeId)
            {
                return null;
            }
            _context.Entry(gradeModel).Reference(b => b.Student).IsModified = false;
            _context.Entry(gradeModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradeModelExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return gradeModel;
        }

        // POST: api/GradeService
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<GradeModel> PostGradeModel(GradeModel gradeModel)
        {
            _context.Grades.Add(gradeModel);
            await _context.SaveChangesAsync();

            return gradeModel;
        }

        // DELETE: api/GradeService/5
        [HttpDelete("{id}")]
        public async Task<GradeModel> DeleteGradeModel(int id)
        {
            var gradeModel = await _context.Grades.FindAsync(id);
            if (gradeModel == null)
            {
                return null;
            }

            _context.Grades.Remove(gradeModel);
            await _context.SaveChangesAsync();

            return gradeModel;
        }

        private bool GradeModelExists(int id)
        {
            return _context.Grades.Any(e => e.GradeId == id);
        }

        bool IGradeService.GradeModelExists(int id)
        {
            return _context.Grades.Any(e => e.GradeId == id);
        }
    }
}
