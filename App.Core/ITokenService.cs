using App.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core
{
    public interface ITokenService
    {
        Task<Writer> AuthenticateUser(LoginToken userCredModel);
    }
}
