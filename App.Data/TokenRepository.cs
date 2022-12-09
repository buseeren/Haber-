using App.Core;
using App.Models.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public class TokenRepository : ITokenRepository
    {
        private readonly NewsDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public TokenRepository(NewsDBContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        


        public async Task<Writer> AuthenticateUser(LoginToken userCredModel)
        {
            using (NewsDBContext newsContext = _context)
            {

                //Writer writer = await newsContext.Writers.Where(x => x.WriteName == userCredModel.UserName).FirstOrDefault();
                Writer writer = await newsContext.Writers
                .Where(x => x.WriteName == userCredModel.UserName)
                .AsSplitQuery()
                .FirstOrDefaultAsync();


                if (writer is null)
                {
                    return null;
                }



                return writer;
            }
        }
    }
}
