﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCVCore.BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void TAdd(T entity);
        void TDelete(T entity);
        void TUpdate(T entity);
        List<T> TGetList();
        T TGetById(int id);
        List<T> TGetByFilter(string p);



    }
}
