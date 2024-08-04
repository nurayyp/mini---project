using Application.Services.Abstract;
using Core.Constants;
using Core.Entities;
using Data.Context;
using Data.UnitOfWork.Concrete;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PasswordVerificationResult = Microsoft.AspNetCore.Identity.PasswordVerificationResult;

namespace Application.Services.Concrete
{
    public class AdminService : IAdminService
    {
        private readonly UnitOfWork _unitOfWork;
        public AdminService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void LoginAsAdmin()
        {
            Messages.InputMessage("Admin");
            string nameOfAdmin = Console.ReadLine();
            Messages.InputMessage("Password");
            string passwordOfAdmin = Console.ReadLine();
            var existAdmin = _unitOfWork.Admins.GetAll().FirstOrDefault(x => x.Name == nameOfAdmin);
            if (existAdmin == null)
            {
                Messages.NotFoundMessage("Admin", nameOfAdmin);
            }
            PasswordHasher<Admin> passwordHasher = new PasswordHasher<Admin>();
            var result = passwordHasher.VerifyHashedPassword(existAdmin, existAdmin.Password, passwordOfAdmin);
            if (result == PasswordVerificationResult.Failed)
            {
                Messages.InvalidInputMessage("Admin information");
            }
            Console.WriteLine("You are logged in successfully");
        }
        public void AddCategory()
        {
            CategoryNameInput: Messages.InputMessage("Name of the category");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Messages.InvalidInputMessage("Name of the category");
                goto CategoryNameInput;
            }
            Category category = new Category()
            {
                Name = name
            };
            _unitOfWork.Categories.Add(category);
            _unitOfWork.Commit();
            Messages.SuccessAddMessage("Category", name);
        }
        public void AddCustomer()
        {
            CustomerNameInput: Messages.InputMessage("Name of the customer");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Messages.InvalidInputMessage("Name of the customer");
                goto CustomerNameInput;
            }
            CustomerSurnameInput: Messages.InputMessage("Surname of the customer");
            string surname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(surname))
            {
                Messages.InvalidInputMessage("Surname of the customer");
                goto CustomerSurnameInput;
            }
            CustomerEmailInput: Messages.InputMessage("Email of the customer");
            string email = Console.ReadLine();    
            bool isEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (!isEmail || string.IsNullOrWhiteSpace(email))
            {
                Messages.InvalidInputMessage("Email of the customer");
                goto CustomerEmailInput;
            }
            var existedEmail = _unitOfWork.Sellers.GetAll().FirstOrDefault(x => x.Email == email);
            if (existedEmail != null)
            {
                Messages.AlreadyExistsMessage("Customer", email);
                goto CustomerEmailInput;
            }
            CustomerPasswordInput: Messages.InputMessage("Password of the customer");
            string password = Console.ReadLine();
            bool isPassword = Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$", RegexOptions.IgnoreCase);
            if (!isPassword || string.IsNullOrWhiteSpace(password)) 
            {
                Messages.InvalidInputMessage("Password of the customer");
                goto CustomerPasswordInput;
            }
            CustomerPhoneNumberInput: Messages.InputMessage("Phone number of the customer");
            string phoneNumber = Console.ReadLine();
            bool isNumber = Regex.IsMatch(phoneNumber, @"^(\+994|0)\s?\d{2}\s?\d{3}\s?\d{4}$", RegexOptions.IgnoreCase);
            if (!isNumber || string.IsNullOrWhiteSpace(phoneNumber))
            {
                Messages.InvalidInputMessage("Phone number of the customer");
                goto CustomerPhoneNumberInput;
            }
            CustomerSeriaNumberInput: Messages.InputMessage("Seria number of the customer");
            string seriaNumber = Console.ReadLine();
            bool isSeria = Regex.IsMatch(seriaNumber, @"^[A-Z0-9]{7}$", RegexOptions.IgnoreCase);
            if (!isSeria || string.IsNullOrWhiteSpace(seriaNumber))
            {
                Messages.InvalidInputMessage("Seria number of the customer");
                goto CustomerSeriaNumberInput;
            }
            Customer customer = new Customer
            {
                Name = name,
                Surname = surname,
                Email = email,
                PhoneNumber = phoneNumber,
                SeriaNumber = seriaNumber,
                Password = password
            };
            _unitOfWork.Customers.Add(customer);
            _unitOfWork.Commit();
            Messages.SuccessAddMessage("Customer", name);
        }
        public void AddSeller()
        {
            SellerNameInput: Messages.InputMessage("Name of the seller");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Messages.InvalidInputMessage("Name of the seller");
                goto SellerNameInput;
            }
            SellerSurnameInput: Messages.InputMessage("Surname of the seller");
            string surname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(surname))
            {
                Messages.InvalidInputMessage("Surname of the seller");
                goto SellerSurnameInput;
            }
            SellerEmailInput: Messages.InputMessage("Email of the seller");
            string email = Console.ReadLine();
            bool isEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (!isEmail || string.IsNullOrWhiteSpace(email))
            {
                Messages.InvalidInputMessage("Email of the seller");
                goto SellerEmailInput;
            }
            var existedEmail = _unitOfWork.Sellers.GetAll().FirstOrDefault(x => x.Email == email);
            if (existedEmail != null)
            {
                Messages.AlreadyExistsMessage("Seller", email);
                goto SellerEmailInput;
            }
            SellerPasswordInput: Messages.InputMessage("Password of the seller");
            string password = Console.ReadLine();
            bool isPassword = Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$", RegexOptions.IgnoreCase);
            if (!isPassword || string.IsNullOrWhiteSpace(password))
            {
                Messages.InvalidInputMessage("Password of the seller");
                goto SellerPasswordInput;
            }
            SellerPhoneNumberInput: Messages.InputMessage("Phone number of the seller");
            string phoneNumber = Console.ReadLine();
            bool isNumber = Regex.IsMatch(phoneNumber, @"^(\+994|0)\s?\d{2}\s?\d{3}\s?\d{4}$", RegexOptions.IgnoreCase);
            if (!isNumber || string.IsNullOrWhiteSpace(phoneNumber))
            {
                Messages.InvalidInputMessage("Phone number of the seller");
                goto SellerPhoneNumberInput;
            }
            SellerSeriaNumberInput: Messages.InputMessage("Seria number of the seller");
            string seriaNumber = Console.ReadLine();
            bool isSeria = Regex.IsMatch(seriaNumber, @"^[A-Z0-9]{7}$", RegexOptions.IgnoreCase);
            if (!isSeria || string.IsNullOrWhiteSpace(seriaNumber))
            {
                Messages.InvalidInputMessage("Seria number of the seller");
                goto SellerSeriaNumberInput;
            }
            Seller seller = new Seller 
            { 
                Name = name,
                Surname = surname,
                Email = email,
                PhoneNumber = phoneNumber,
                SeriaNumber = seriaNumber,
                Password = password,
            };
            _unitOfWork.Sellers.Add(seller);
            _unitOfWork.Commit();
            Messages.SuccessAddMessage("Seller", name);
        }
        public void DeleteCustomer()
        {
            GetAllCustomers();
            IdInput: Messages.InputMessage("Customer id which you want to change");
            int selectedId = Convert.ToInt32(Console.ReadLine());
            bool isSucceeded = int.TryParse(Console.ReadLine(), out selectedId);
            if (!isSucceeded)
            {
                Messages.InvalidInputMessage("Id of the seller");
                goto IdInput;
            }
            else
            {
                var selectedCustomer = _unitOfWork.Customers.GetAll().FirstOrDefault(c => c.Id == selectedId);
                if (selectedCustomer is null)
                {
                    Messages.ErrorOccuredMessage();
                    goto IdInput;
                }
                _unitOfWork.Customers.Delete(selectedCustomer);
                _unitOfWork.Commit();
                Messages.SuccessDeleteMessage("Customer");
            }
        }
        public void DeleteSeller()
        {
            GetAllSellers();
            IdInput: Messages.InputMessage("Seller id which you want to change");
            int selectedId = Convert.ToInt32(Console.ReadLine());
            bool isSucceeded = int.TryParse(Console.ReadLine(), out selectedId);
            if (!isSucceeded)
            {
                Messages.InvalidInputMessage("Id of the seller");
                goto IdInput;
            }
            else
            {
                var  selectedSeller = _unitOfWork.Sellers.GetAll().FirstOrDefault(c => c.Id == selectedId);
                if (selectedSeller is null)
                {
                    Messages.ErrorOccuredMessage();
                    goto IdInput;
                }
                _unitOfWork.Sellers.Delete(selectedSeller);
                _unitOfWork.Commit();
                Messages.SuccessDeleteMessage("Seller");
            }
        }
        public void GetAllCustomers()
        {
            foreach (var customer in _unitOfWork.Customers.GetAll())
            {
                Console.WriteLine($"{customer.Id} - {customer.Name} {customer.Surname} - Email: {customer.Email} - Seria Number: {customer.SeriaNumber}");
            }
            if (_unitOfWork.Customers.GetAll().Count == 0)
            {
                Messages.ErrorOccuredMessage();
            }
        }
        public void GetAllSellers()
        {
            foreach (var seller in _unitOfWork.Sellers.GetAll())
            {
                Console.WriteLine($"{seller.Id} - {seller.Name} {seller.Surname} - Email: {seller.Email} - Seria Number: {seller.SeriaNumber}");
            }
            if (_unitOfWork.Sellers.GetAll().Count == 0)
            {
                Messages.ErrorOccuredMessage();
            }
        }
        public void GetAllOrdersByDate()
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
                    Console.WriteLine($"{order.Id} - {order.CustomerId} ");
                }
            }
        }
        public void GetAllOrdersOfCustomer()
        {
            IdInput: Messages.InputMessage("Customer Id");
            int Id = Convert.ToInt32( Console.ReadLine() );
            bool isSucceeded = int.TryParse( Console.ReadLine(), out Id); 
            if (!isSucceeded)
            {
                Messages.ErrorOccuredMessage();
                goto IdInput;
            }
            foreach (var order in _unitOfWork.Orders.GetAll())
            {
                if (order.CustomerId == Id )
                {
                    Console.WriteLine($"{order.Id} by {order.CustomerId}");
                }
            }
        }
        //public void GetAllOrdersOfSeller()
        //{
        //IdInput: Messages.InputMessage("Seller Id");
        //    int Id = Convert.ToInt32(Console.ReadLine());
        //    bool isSucceeded = int.TryParse(Console.ReadLine(), out Id);
        //    if (!isSucceeded)
        //    {
        //        Messages.ErrorOccuredMessage();
        //        goto IdInput;
        //    }
        //    foreach (var order in _unitOfWork.Orders.GetAll())
        //    {
        //        if (order.Product.SellerId == Id)
        //        {
        //            Console.WriteLine($"{order.Id} by {order.SellerId}");
        //        }
        //    }
        //}
        public void Exit()
        {
            return;
        }
    }
}
