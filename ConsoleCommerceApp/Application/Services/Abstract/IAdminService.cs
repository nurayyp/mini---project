using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abstract
{
    public interface IAdminService
    {
        public void Exit();
        public void AddCustomer();
        public void DeleteCustomer();
        public void GetAllCustomers();
        public void AddSeller();
        public void DeleteSeller();
        public void GetAllSellers();
        public void AddCategory();
        public void GetAllOrdersByDate();
        public void GetAllOrdersOfCustomer();
    }
}
