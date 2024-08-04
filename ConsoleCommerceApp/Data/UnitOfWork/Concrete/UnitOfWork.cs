using Core.Constants;
using Data.Context;
using Data.Repositories.Abstract;
using Data.Repositories.Concrete;
using Data.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Data.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly CustomerRepository Customers;
        public readonly SellerRepository Sellers;
        public readonly AdminRepositrory Admins;
        public readonly CategoryRepository Categories;
        public readonly OrderReepository Orders;
        public readonly ProductRepository Products;
        private readonly ApplicationDbContext _context;
        public UnitOfWork()
        {
            _context = new ApplicationDbContext();
            Customers = new CustomerRepository(_context);
            Admins = new AdminRepositrory(_context);
            Categories = new CategoryRepository(_context);
            Products = new ProductRepository(_context);
            Sellers = new SellerRepository(_context);
            Orders = new OrderReepository(_context);
        }
        public void Commit()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                Messages.ErrorOccuredMessage();
            }
        }
    }
}
