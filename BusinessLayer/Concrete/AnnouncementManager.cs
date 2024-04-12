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
    public class AnnouncementManager : IAnnouncementService
    {
        IAnnouncementDal _announcementDal;

        public AnnouncementManager(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }

        public void TAdd(Announcement entity)
        {
           _announcementDal.Insert(entity);
        }

        public void TDelete(Announcement entity)
        {
            throw new NotImplementedException();
        }

        public List<Announcement> TGetByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public Announcement TGetById(int id)
        {
            return _announcementDal.GetById(id);    
        }

        public List<Announcement> TGetList()
        {
            return _announcementDal.GetListAll();
        }

        public void TUpdate(Announcement entity)
        {
            throw new NotImplementedException();
        }
    }
}
