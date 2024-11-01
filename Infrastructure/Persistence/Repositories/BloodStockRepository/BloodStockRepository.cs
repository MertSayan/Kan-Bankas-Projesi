using Application.Interfaces.BloodStockInterface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.BloodStockRepository
{
    public class BloodStockRepository : IBloodStockRepository
    {
        private readonly KanBankasıContext _context;

        public BloodStockRepository(KanBankasıContext context)
        {
            _context = context;
        }

        public async Task<List<BloodStock>> GetAllBloodStockWithBloodName()
        {
            var result = await _context.BloodStocks
                .Include(x => x.BloodType)
                .Where(x=>x.DeletedDate==null)
                .ToListAsync();
            return result;
        }
    }
}
