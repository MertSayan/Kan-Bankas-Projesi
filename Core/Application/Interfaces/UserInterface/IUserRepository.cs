using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UserInterface
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUserWithRoleAndBloodTypeName();
        Task<User> GetUserByIdWithRoleAndBloodTypeName(int id);
    }
}
