using Application.Features.Mediatr.Users.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Users.Queries
{
    public class GetUserByIdWithRoleAndBloodTypeNameAndDonationAndRequestCountQuery:IRequest<GetUserByIdWithRoleAndBloodTypeNameAndDonationAndRequestCountQueryResult>
    {
        public int Id { get; set; }

        public GetUserByIdWithRoleAndBloodTypeNameAndDonationAndRequestCountQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
