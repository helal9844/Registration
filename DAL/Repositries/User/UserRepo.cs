using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserRepo : GenaticRepo<User>,IUserRepo
    {
        private readonly SkyContext _skyContext;
        public UserRepo(SkyContext skyContext) : base(skyContext)
        {
            _skyContext = skyContext;
        }
        
        public List<User> GetUsersWithCountry()
        {
            return _skyContext.Set<User>().Include(P => P.Country).ToList();
        }
        
    }
}   
