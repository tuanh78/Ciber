using Ciber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.Repositories
{
    public interface IUserRepository
    {
        UserDTO GetUser(UserModel userMode);
    }
}
