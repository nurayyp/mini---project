using Core.Entities;
using Data.Context;
using Data.Repositories.Abstract;
using Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Concrete
{
    public class OrderReepository : Repository<Order>, IOrderRepository
    {
        public OrderReepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
