using Application.Interfaces.UserInterface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Linq.Expressions;

namespace Persistence.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly KanBankasıContext _context;
            
        public UserRepository(KanBankasıContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUserWithRoleAndBloodTypeName()
        {
            var values=await _context.Users
                .Include(x=>x.BloodType)
                .Include(x=>x.Role)
                .Where(x=>x.DeletedDate==null)
                .ToListAsync();
            return values;
        }

        public async Task<User> GetByFilterAsync(Expression<Func<User, bool>> filter)
        {
            var values = await _context.Users.Where(filter)
                .Include(x => x.BloodType)
                .Include(x => x.Role)
                .FirstOrDefaultAsync();
            return values;
        }

        public async Task<User> GetUserByIdWithRoleAndBloodTypeName(int id)
        {
            var value = await _context.Users
               .Include(x => x.BloodType)
               .Include(x => x.Role)
               .FirstOrDefaultAsync(x => x.UserId == id && x.DeletedDate == null);
            return value;

        }

        public async Task<User> GetUserByIdWithRoleAndBloodTypeNameAndDonationAndRequestCount(int id)
        {
            var user = await _context.Users
                .Include(x => x.BloodType)
                .Include(x => x.Role)
                .Include(x => x.Donations)
                .Include(x => x.Requests)
                .FirstOrDefaultAsync(x => x.UserId == id && x.DeletedDate == null);

            if (user != null)
            {
                user.TotalDonationsAmount = user.Donations.Sum(d => d.Amount);
                user.TotalRequestsAmount = user.Requests.Sum(y=>y.Amount);
            }

            return user;
        }


    }
}
