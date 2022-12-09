using App.Core;
using App.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service
{
    public class TokenService : ITokenService
    {
        ITokenRepository _tokenRepository;

        public TokenService(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }


        public async Task<Writer> AuthenticateUser(LoginToken userCredModel)
        {
            return await _tokenRepository.AuthenticateUser(userCredModel);
        }
    }
}
