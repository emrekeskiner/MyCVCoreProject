using MyCVCore.BusinessLayer.Abstract;
using MyCVCore.DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCVCore.BusinessLayer.Concrete
{
    public class ToDoListManager : IToDoListService
    {

        IToDoListDal _toDoListDal;

        public ToDoListManager(IToDoListDal toDoListDal)
        {
            _toDoListDal = toDoListDal;
        }

        public void TAdd(ToDoList entity)
        {
            _toDoListDal.Insert(entity);
        }

        public void TDelete(ToDoList entity)
        {
            _toDoListDal.Delete(entity);
        }

        public List<ToDoList> TGetByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public ToDoList TGetById(int id)
        {
            return _toDoListDal.GetById(id);
        }

        public List<ToDoList> TGetList()
        {
            return _toDoListDal.GetListAll();
        }

        public void TUpdate(ToDoList entity)
        {
             _toDoListDal.Update(entity);
        }
    }
}
