using MyCVCore.DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCVCore.BusinessLayer.Abstract
{
    public interface IUserService : IGenericService<User>
    {
    }
}
