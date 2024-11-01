using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.DonationInterface
{
    public interface IDonationRepsitory
    {
        Task<List<Donation>> GetAllDonationWithUserNameAndBloodTypeName();
    }
}
