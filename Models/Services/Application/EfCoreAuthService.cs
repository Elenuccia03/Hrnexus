using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HrNexus.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HrNexus.Models.Services.Application
{
    public class EfCoreAuthService : IAuthService
    { 
        private readonly MyCourseDbContext dbContext;

        public EfCoreAuthService(MyDbContext dbContext){
            this.dbContext = dbContext;
        }

        
        public async Task<User> Login(User user)
        {
            bool findPassword = false;
            bool findUserAzienda = await dbContext.Aziende.AnyAsync(a => a.Username == user.Username);
            bool findUserDipendete = await dbContext.Dipendenti.AnyAsync(d => d.Username == user.Username);
            if (findUserAzienda == true ){
                findPassword = await dbContext.Azienda.AnyAsync(a => a.Password == user.Password);
                return user;
            }
            if (findUserDipendete == true ){
                findPassword = await dbContext.Azienda.AnyAsync(a => a.Password == user.Password);
                return user;
            } 
        }

        }
}