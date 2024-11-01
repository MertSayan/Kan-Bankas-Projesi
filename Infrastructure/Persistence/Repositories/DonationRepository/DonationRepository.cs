using Application.Interfaces.DonationInterface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.DonationRepository
{
    public class DonationRepository : IDonationRepsitory
    {

        private readonly KanBankasıContext _context;

        public DonationRepository(KanBankasıContext context)
        {
            _context = context;
        }

        public async Task<List<Donation>> GetAllDonationWithUserNameAndBloodTypeName()
        {
            var values = await _context.Donations
                .Include(x => x.User)
                .Include(x => x.BloodType)
                .Where(x => x.DeletedDate == null)
                .ToListAsync();
            return values;
        }
    }
}
