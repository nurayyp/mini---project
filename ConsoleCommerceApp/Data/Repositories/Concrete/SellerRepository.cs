using Core.Entities;
using Data.Context;
using Data.Repositories.Abstract;
using Data.Repositories.Base;

namespace Data.Repositories.Concrete
{
    public class SellerRepository : Repository<Seller>, ISellerRepository   
    {
        public SellerRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
