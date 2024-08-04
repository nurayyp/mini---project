using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants.Operations
{
    public enum SellerOperations
    {
        Exit,
        AddNewProduct,
        UpdateCountOfProduct,
        DeleteProduct,
        GetSoldProducts,
        GetSoldProductsWithGivenDate,
        GetProductsWithFilter,
        GetTotalIncome
    }
}
