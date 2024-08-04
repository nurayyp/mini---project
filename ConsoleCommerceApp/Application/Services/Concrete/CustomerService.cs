using Application.Services.Abstract;
using Core.Constants;
using Core.Entities;
using Data.UnitOfWork.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly UnitOfWork _unitOfWork;
            int customerId;
        public CustomerService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void LoginAsCustomer()
        {
            Messages.InputMessage("Customer Email Adress");
            string email = Console.ReadLine();
            Messages.InputMessage("Password");
            string password = Console.ReadLine();
            var custommer = _unitOfWork.Customers.GetAll().FirstOrDefault(x => x.Name == email);
            if (custommer == null)
            {
                Messages.NotFoundMessage("Customer", email);
            }
            PasswordHasher<Customer> passwordHasher = new PasswordHasher<Customer>();
            var result = passwordHasher.VerifyHashedPassword(custommer, custommer.Password, password);
            if (result == PasswordVerificationResult.Failed)
            {
                Messages.InvalidInputMessage("Customer information");
            }
            Console.WriteLine("You are logged in successfully");
            customerId=custommer.Id;
        }
        public void BuyProduct()
        {
            _unitOfWork.Products.GetAll();
            Input: Messages.InputMessage("Product id");
            string input = Console.ReadLine();
            int productId;
            bool isTrue = int.TryParse(input, out productId);
            if (!isTrue)
            {
                Messages.ErrorOccuredMessage();
                goto Input;
            }
            var product = _unitOfWork.Products.GetAll().FirstOrDefault(x => x.Id == productId);
            if (product is null)
            {
                Messages.NotFoundMessage("product", input);
            }
            CountInput: Messages.InputMessage("Count of product");
            int count = Convert.ToInt32(Console.ReadLine());
            product.Count -= count;
            _unitOfWork.Products.Update(product);
            Order order = new Order
            {
                TotalCount = count,
                CreatedDate = DateTime.Now,
                TotalPrice = count * product.Price,
                ProductId = productId,
                Product = product,
                CustomerId = customerId,
                Customer = _unitOfWork.Customers.GetAll().FirstOrDefault(x => x.Id == customerId)
            };
            _unitOfWork.Orders.Add(order);
            _unitOfWork.Commit();
        }
        public void GetOrderedProducts()
        {
            
        }
        public void GetOrderedProductsWithDate()
        {
            DateInput: Messages.InputMessage("Order Created Date");
            DateTime dateOfOrders = Convert.ToDateTime(Console.ReadLine());
            bool isTrue = DateTime.TryParse(Console.ReadLine(), out dateOfOrders);
            if (!isTrue)
            {
                Messages.ErrorOccuredMessage();
                goto DateInput;
            }
            foreach (var order in _unitOfWork.Orders.GetAll())
            {
                if (dateOfOrders == order.CreatedDate)
                {
                    
                }
            }
        }
        public void GetProductsWithFilter()
        {
            throw new NotImplementedException();
        }
        public void Exit()
        {
            return;
        }
    }
}
