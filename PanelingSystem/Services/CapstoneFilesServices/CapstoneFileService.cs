﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PanelingSystem.DatabaseContext;
using PanelingSystem.Models;

namespace PanelingSystem.Services.CapstoneFilesServices
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapstoneFileService : ControllerBase, ICapstoneFileService
    {
        private readonly AppDBContext _context;

        public CapstoneFileService(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/CapstoneFileService
        [HttpGet]
        public async Task<IEnumerable<CapstoneFileModel>> GetCapstoneFiles()
        {
            return await _context.CapstoneFiles.ToListAsync();
        }
        [HttpGet]
        public async Task<IEnumerable<CapstoneFileModel>> GetCapstoneFilesWithGroup(int GroupId)
        {
            return await _context.CapstoneFiles.Where( e => e.GroupId == GroupId).ToListAsync();
        }
        [HttpGet]
        public async Task<CapstoneFileModel> GetCapstoneFilesWithGroup2(int GroupId, Enums.Chapter chapter)
        {
            return await _context.CapstoneFiles.Where(e => e.GroupId == GroupId && e.Chapter == chapter).FirstOrDefaultAsync() ?? new();
        }

        // GET: api/CapstoneFileService/5
        [HttpGet("{id}")]
        public async Task<CapstoneFileModel> GetCapstoneFileModel(int id)
        {
            var capstoneFileModel = await _context.CapstoneFiles.FindAsync(id);

            if (capstoneFileModel == null)
            {
                return null;
            }

            return capstoneFileModel;
        }

        // PUT: api/CapstoneFileService/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<CapstoneFileModel> PutCapstoneFileModel(int id, CapstoneFileModel capstoneFileModel)
        {
            if (id != capstoneFileModel.CapstoneFileId)
            {
                return null;
            }

            _context.Entry(capstoneFileModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CapstoneFileModelExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return capstoneFileModel;
        }

        // POST: api/CapstoneFileService
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<CapstoneFileModel> PostCapstoneFileModel(CapstoneFileModel capstoneFileModel)
        {
            if (String.IsNullOrEmpty(capstoneFileModel.Title))
                capstoneFileModel.Title = "No Title";
            _context.CapstoneFiles.Add(capstoneFileModel);
            await _context.SaveChangesAsync();

            return capstoneFileModel;
        }

        // DELETE: api/CapstoneFileService/5
        [HttpDelete("{id}")]
        public async Task<CapstoneFileModel> DeleteCapstoneFileModel(int id)
        {
            var capstoneFileModel = await _context.CapstoneFiles.FindAsync(id);
            if (capstoneFileModel == null)
            {
                return null;
            }

            _context.CapstoneFiles.Remove(capstoneFileModel);
            await _context.SaveChangesAsync();

            return capstoneFileModel;
        }

        private bool CapstoneFileModelExists(int id)
        {
            return _context.CapstoneFiles.Any(e => e.CapstoneFileId == id);
        }

        bool ICapstoneFileService.CapstoneFileModelExists(int id)
        {
            return _context.CapstoneFiles.Any(e => e.CapstoneFileId == id);
        }
    }
}
