﻿using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Base
{
    public interface IRepository<T> where T : BaseEntity
    {
        List<T> GetAll();
        void Add(T item);
        void Update(T item);
        void Delete(T item);
    }
}
