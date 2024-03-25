using MyCVCore.DataAccessLayer.Abstract;
using MyCVCore.DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCVCore.DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace MyCVCore.DataAccessLayer.EntityFramework
{
    public class EfUserMessageDal : GenericRepository<UserMessage>, IUserMessageDal
    {
        public List<UserMessage> GetUserMessagesWithUser()
        {
            using (var c = new CvContext())
            {
                return c.UserMessages.Include(x=>x.User).ToList();
            }
        }
    }
}
