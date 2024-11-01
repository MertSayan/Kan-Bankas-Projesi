using Application.Interfaces.RequestInterface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.RequestRepository
{
    public class RequestRepository : IRequestRepository
    {
        private readonly KanBankasıContext _context;

        public RequestRepository(KanBankasıContext context)
        {
            _context = context;
        }
        public async Task<List<Request>> GetAllRequestWithUserNameAndBloodTypeName()
        {
            var values=await _context.Requests
                .Include(x=>x.User)
                .Include(x=>x.BloodType)
                .Where(x=>x.DeletedDate==null)
                .ToListAsync();
            return values;
        }
    }
}
