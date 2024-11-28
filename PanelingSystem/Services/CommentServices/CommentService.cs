using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PanelingSystem.DatabaseContext;
using PanelingSystem.Models;

namespace PanelingSystem.Services.CommentServices
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentService : ControllerBase , ICommentService
    {
        private readonly AppDBContext _context;

        public CommentService(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/CommentService
        [HttpGet]
        public async Task<IEnumerable<CommentModel>> GetComments(Enums.Chapter chap)
        {
            return await _context.Comments.Where( e => e.Chapter == chap)
            .Include( e => e.Account).ToListAsync();
        }
        [HttpGet]
        public async Task<IEnumerable<CommentModel>> GetCommentsByGroupAndChapter(GroupModel group, Enums.Chapter chapter)
        {
            return await _context.Comments.Where( e => e.Chapter == chapter && e.GroupId == group.GroupId).Include( e => e.Account).ToListAsync();
        }

        // GET: api/CommentService/5
        [HttpGet("{id}")]
        public async Task<CommentModel> GetCommentModel(int id)
        {
            var commentModel = await _context.Comments.FindAsync(id);

            if (commentModel == null)
            {
                return null;
            }

            return commentModel;
        }

        // PUT: api/CommentService/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<CommentModel> PutCommentModel(int id, CommentModel commentModel)
        {
            if (id != commentModel.CommentId)
            {
                return null;
            }

            _context.Entry(commentModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentModelExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return commentModel;
        }

        // POST: api/CommentService
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<CommentModel> PostCommentModel(CommentModel commentModel)
        {
            _context.Comments.Add(commentModel);
            await _context.SaveChangesAsync();

            return commentModel;
        }

        // DELETE: api/CommentService/5
        [HttpDelete("{id}")]
        public async Task<CommentModel> DeleteCommentModel(int id)
        {
            var commentModel = await _context.Comments.FindAsync(id);
            if (commentModel == null)
            {
                return null;
            }

            _context.Comments.Remove(commentModel);
            await _context.SaveChangesAsync();

            return commentModel;
        }

        private bool CommentModelExists(int id)
        {
            return _context.Comments.Any(e => e.CommentId == id);
        }
    }
}
