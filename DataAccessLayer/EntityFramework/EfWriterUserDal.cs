using MyCVCore.DataAccessLayer.Abstract;
using MyCVCore.DataAccessLayer.Repositories;
using MyCVCore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCVCore.DataAccessLayer.EntityFramework
{
    public class EfWriterUserDal: GenericRepository<WriterUser>,IWriterUserDal
    {
    }
}
