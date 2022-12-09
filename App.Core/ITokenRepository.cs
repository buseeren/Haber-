using App.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core
{
    public interface ITokenRepository
    {
        Task<Writer> AuthenticateUser(LoginToken userCredModel);
    }
}
