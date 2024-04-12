using MyCVCore.BusinessLayer.Abstract;
using MyCVCore.DataAccessLayer.Abstract;
using MyCVCore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCVCore.BusinessLayer.Concrete
{
    public class WriterUserManager : IWriterUserService
    {
        private readonly IWriterUserDal _writerUserDal;

        public WriterUserManager(IWriterUserDal writerUserDal)
        {
            _writerUserDal = writerUserDal;
        }

        public void TAdd(WriterUser entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(WriterUser entity)
        {
            throw new NotImplementedException();
        }

        public List<WriterUser> TGetByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public WriterUser TGetById(int id)
        {
            return _writerUserDal.GetById(id);
        }

        public List<WriterUser> TGetList()
        {
            return _writerUserDal.GetListAll();
        }

        public void TUpdate(WriterUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
