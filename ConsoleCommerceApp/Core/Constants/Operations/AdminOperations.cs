using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants.Operations
{
    public enum AdminOperations
    {
        Exit,
        AddCustomer,
        DeleteCustomer,
        GetAllCustomers,
        AddSeller,
        DeleteSeller,
        GetAllSellers,
        AddCategory,
        GetAllOrdersByDate,
        GetAllOrdersOfCustomer,
        GetAllOrdersOfSeller,
        GetOrdersForGivenDate
    }
}
