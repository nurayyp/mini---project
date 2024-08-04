using Application.Services.Abstract;
using Application.Services.Concrete;
using Core.Constants.Operations;
using Data.UnitOfWork.Concrete;
using Microsoft.Identity.Client;
using System.Net.WebSockets;

namespace ConsoleCommerceApp
{
    public class Program()
    {
        private static readonly UnitOfWork _unitOfWork;
        private static readonly AdminService _adminService;
        private static readonly SellerService _sellerService;
        private static readonly CustomerService _customerService;
        static Program()
        {
            _unitOfWork = new UnitOfWork();
            _adminService = new AdminService(_unitOfWork);
            _sellerService = new SellerService(_unitOfWork);
            _customerService = new CustomerService(_unitOfWork);
        }
        public static void Main()
        {
            while (true)
            {
                Console.WriteLine("-MENU-");
                Console.WriteLine("1 - Admin Login");
                Console.WriteLine("2 - Seller Login");
                Console.WriteLine("3 - Customer Login");
                Console.WriteLine("0 - Exit");
                int choiceForLogin = Convert.ToInt32(Console.ReadLine());
                switch ((LoginPageOperations)choiceForLogin)
                {
                    case LoginPageOperations.AdminLogin:
                        AdminMenu();
                        break;
                    case LoginPageOperations.SellerLogin:
                        SellerMenu();
                        break;
                    case LoginPageOperations.CustomerLogin:
                        CustomerMenu();
                        break;
                    default:
                        break;
                }
            }
            void AdminMenu()
            {
                while (true)
                {
                    Console.WriteLine("-ADMIN_MENU-");
                    Console.WriteLine("1 - AddCustomer");
                    Console.WriteLine("2 - DeleteCustomer");
                    Console.WriteLine("3 - GetAllCustomers");
                    Console.WriteLine("4 - AddSeller");
                    Console.WriteLine("5 - DeleteSeller");
                    Console.WriteLine("6 - GetAllSellers");
                    Console.WriteLine("7 - AddCategory");
                    Console.WriteLine("8 - GetAllOrdersByDate");
                    Console.WriteLine("9 - GetAllOrdersOfCustomer");
                    Console.WriteLine("10 - GetAllOrdersOfSeller");
                    Console.WriteLine("11- GetOrdersForGivenDate");
                    Console.WriteLine("0 - Exit");
                    int choiceForAdmin = Convert.ToInt32(Console.ReadLine());
                    switch ((AdminOperations)choiceForAdmin)
                    {
                        case AdminOperations.AddCustomer:
                            _adminService.AddCustomer();
                            break;
                        case AdminOperations.GetAllCustomers:
                            _adminService.GetAllCustomers();
                            break;
                        case AdminOperations.DeleteCustomer:
                            _adminService.DeleteCustomer();
                            break;
                        case AdminOperations.AddSeller:
                            _adminService.AddSeller();
                            break;
                        case AdminOperations.GetAllSellers:
                            _adminService.GetAllSellers();
                            break;
                        case AdminOperations.DeleteSeller:
                            _adminService.DeleteSeller();
                            break;
                        case AdminOperations.AddCategory:
                            _adminService.AddCategory();
                            break;
                        case AdminOperations.GetAllOrdersByDate:
                            _adminService.GetAllOrdersByDate();
                            break;
                        case AdminOperations.GetAllOrdersOfCustomer:
                            _adminService.GetAllOrdersOfCustomer();
                            break;
                        case AdminOperations.Exit:
                            return;
                        default:
                            break;
                    }
                }
            }
            void SellerMenu()
            {
                if (_sellerService.LoginAsSeller())
                {
                    while (true)
                    {
                        Console.WriteLine("-SELLER_MENU-");
                        Console.WriteLine("1 - AddNewProduct");
                        Console.WriteLine("2 - UpdateCountOfProduct");
                        Console.WriteLine("3 - DeleteProduct");
                        Console.WriteLine("4 - GetSoldProducts");
                        Console.WriteLine("5 - GetSoldProductsWithGivenDate");
                        Console.WriteLine("6 - GetProductsWithFilter");
                        Console.WriteLine("7 - GetTotalIncome");
                        Console.WriteLine("0 - Exit");
                        int choiceForSeller = Convert.ToInt32(Console.ReadLine());
                        switch ((SellerOperations)choiceForSeller)
                        {
                            case SellerOperations.AddNewProduct:
                                _sellerService.AddNewProduct();
                                break;
                            case SellerOperations.DeleteProduct:
                                _sellerService.DeleteProduct();
                                break;
                            case SellerOperations.Exit:
                                return;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    return;
                }
                
            }
            void CustomerMenu()
            {
                while (true)
                {
                    Console.WriteLine("-CUSTOMER_MENU-");
                    Console.WriteLine("1 - BuyProduct");
                    Console.WriteLine("2 - GetOrderedProducts");
                    Console.WriteLine("3 - GetOrderedProductsWithDate");
                    Console.WriteLine("4 - GetProductsWithFilter");
                    Console.WriteLine("0 - Exit");
                    int choiceForCustomer = Convert.ToInt32(Console.ReadLine());
                    switch ((CustomerOperations)choiceForCustomer)
                    {
                        case CustomerOperations.BuyProduct:
                            _customerService.BuyProduct();
                            break;
                        case CustomerOperations.Exit:
                            return;
                        default:
                            break;
                    }
                }
            }
            
        }
    }
}