﻿using Core.Entities;
using Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Data.Repositories.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
    }
}
