using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PanelingSystem.DatabaseContext;
using PanelingSystem.Models;

namespace PanelingSystem.Services.FileServices
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileService : ControllerBase , IFileService
    {
        private readonly AppDBContext _context;

        public FileService(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/FileService
        [HttpGet]
        public async Task<IEnumerable<FileModel>> GetFiles()
        {
            return await _context.Files.ToListAsync();
        }
        [HttpGet]
        public async Task<IEnumerable<FileModel>> GetFilesPerPosition(Enums.FilePosition position , int groupId)
        {
            return await _context.Files
                .Where( e => e.FilePosition == position && e.GroupId == groupId).ToListAsync();
        }

        // GET: api/FileService/5
        [HttpGet("{id}")]
        public async Task<FileModel> GetFileModel(int id)
        {
            var fileModel = await _context.Files.FindAsync(id);

            if (fileModel == null)
            {
                return null;
            }

            return fileModel;
        }

        // PUT: api/FileService/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<FileModel> PutFileModel(int id, FileModel fileModel)
        {
            if (id != fileModel.FileId)
            {
                return null;
            }

            _context.Entry(fileModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FileModelExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return fileModel;
        }

        // POST: api/FileService
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<FileModel> PostFileModel(FileModel fileModel)
        {
            _context.Files.Add(fileModel);
            await _context.SaveChangesAsync();

            return fileModel;
        }

        // DELETE: api/FileService/5
        [HttpDelete("{id}")]
        public async Task<FileModel> DeleteFileModel(int id)
        {
            var fileModel = await _context.Files.FindAsync(id);
            if (fileModel == null)
            {
                return null;
            }

            _context.Files.Remove(fileModel);
            await _context.SaveChangesAsync();

            return fileModel;
        }

        private bool FileModelExists(int id)
        {
            return _context.Files.Any(e => e.FileId == id);
        }
    }
}
