using DataAccesLayer.Repositories;
using EntityLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntityFramework
{
    public class EfUserRepository : GenericRepository<User>, IUserDal
    {
        
    }
}
