using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PanelingSystem.DatabaseContext;
using PanelingSystem.Models;

namespace PanelingSystem.Services.AccountServices
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountService : ControllerBase, IAccountService
    {
        private readonly AppDBContext _context;

        public AccountService(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/AccountService
   
        public async Task<IEnumerable<UserAccountModel>> GetAccounts()
        {
            return await _context.Accounts.ToListAsync();
        }
        public async Task<IEnumerable<UserAccountModel>> GetStudentsAccount()
        {
            return await _context.Accounts.Where( e => e.AccountType == Enums.AccountType.Student).ToListAsync();
        }
        public async Task<IEnumerable<UserAccountModel>> GetAccountsNoStudents()
        {
            return await _context.Accounts.Where( e => e.AccountType != Enums.AccountType.Student).ToListAsync();
        }

        // GET: api/AccountService/5
        [HttpGet("{id}")]
        public async Task<UserAccountModel> GetUserAccountModel(int id)
        {
            var userAccountModel = await _context.Accounts.FindAsync(id);

            if (userAccountModel == null)
            {
                return null;
            }

            return userAccountModel;
        }

        // PUT: api/AccountService/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<UserAccountModel> PutUserAccountModel(int id, UserAccountModel userAccountModel)
        {
            if (id != userAccountModel.UserId)
            {
                return null;
            }

            _context.Entry(userAccountModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAccountModelExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return null;
        }

        // POST: api/AccountService
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<UserAccountModel> PostUserAccountModel(UserAccountModel userAccountModel)
        {
            _context.Accounts.Add(userAccountModel);
            await _context.SaveChangesAsync();

            return userAccountModel;
        }

        // DELETE: api/AccountService/5
        [HttpDelete("{id}")]
        public async Task<UserAccountModel> DeleteUserAccountModel(int id)
        {
            var userAccountModel = await _context.Accounts.FindAsync(id);
            if (userAccountModel == null)
            {
                return null;
            }

            _context.Accounts.Remove(userAccountModel);
            await _context.SaveChangesAsync();

            return null;
        }

        private bool UserAccountModelExists(int id)
        {
            return _context.Accounts.Any(e => e.UserId == id);
        }

        public async Task<UserAccountModel> Authenticate(string username, string password)
        {
            return await _context.Accounts.FirstOrDefaultAsync(e => e.UserName == username && e.Password == password);
        }
    }
}
