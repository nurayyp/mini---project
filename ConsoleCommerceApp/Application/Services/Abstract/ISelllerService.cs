using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abstract
{
    public interface ISelllerService
    {
        public void Exit();
        public void AddNewProduct();
        public void UpdateCountOfProduct();
        public void DeleteProduct();
        public void GetSoldProducts();
        public void GetSoldProductsWithGivenDate();
        public void GetProductsWithFilter();
        public void GetTotalIncome();
    }
}
