using Application.Services.Abstract;
using Core.Constants;
using Core.Entities;
using Data.Repositories.Abstract;
using Data.UnitOfWork.Concrete;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;


namespace Application.Services.Concrete
{
    public class SellerService : ISelllerService
    {
        private readonly UnitOfWork _unitOfWork;
          int sellerId;
        public SellerService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool LoginAsSeller()
        {
            Messages.InputMessage("Seller Email Adress");
            string email = Console.ReadLine();
            Messages.InputMessage("Password");
            string password = Console.ReadLine();
            var seller = _unitOfWork.Sellers.GetAll().FirstOrDefault(x => x.Email == email);
            if (seller == null)
            {
                Messages.NotFoundMessage("Seller", email);
                return false;
            }
            //PasswordHasher<Seller> passwordHasher = new PasswordHasher<Seller>();
            //var result = passwordHasher.VerifyHashedPassword(seller, seller.Password, password);
            //if (result == PasswordVerificationResult.Failed)
            //{
            //    Messages.InvalidInputMessage("Seller information");
            //    return false;
            //}
            if (seller.Password == password) 
            {
                Console.WriteLine("You are logged in successfully");
                sellerId = seller.Id;
                return true;
            }
            return false;
        }
        public void AddNewProduct()
        {
            foreach (var category in _unitOfWork.Categories.GetAll())
            {
                Console.WriteLine($"{category.Id}, {category.Name}");
            }
            CategoryIdInput: Messages.InputMessage("Id of the category");
            int categoryId = Convert.ToInt32(Console.ReadLine());
           
            ProductNameInput: Messages.InputMessage("Name of the product");
                string name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name))
                {
                ProductPriceInput: Messages.InputMessage("Price of the product");
                    string input = Console.ReadLine();
                    decimal price;
                    bool isSucceeded = decimal.TryParse(input, out price);
                    if (isSucceeded)
                    {
                    ProductCountInput: Messages.InputMessage("Count of the product");
                        
                        bool isTrue = int.TryParse(Console.ReadLine(), out int count);
                        if (isTrue)
                        {
                            Product product = new Product
                            {
                                Name = name,
                                Price = price,
                                Count = count,
                                SellerId = sellerId,
                                seller = _unitOfWork.Sellers.GetAll().FirstOrDefault(x => x.Id == sellerId),
                                CategoryId = categoryId,
                                category = _unitOfWork.Categories.GetAll().FirstOrDefault(x => x.Id == categoryId)

                            };
                            _unitOfWork.Products.Add(product);
                            _unitOfWork.Commit();
                        }
                        else
                    {
                        Messages.InvalidInputMessage("Count of the product");
                        goto ProductCountInput;
                    }
                            
                    }
                    else
                {
                    Messages.InvalidInputMessage("Price of the product");
                    goto ProductPriceInput;
                }
                        
                }
                else
            {
                Messages.InvalidInputMessage("Name of the product");
                goto ProductNameInput;

            }

        }

        public void DeleteProduct()
        {
            _unitOfWork.Products.GetAll();
            Messages.InputMessage("Product Id");
            int id =  Convert.ToInt32(Console.ReadLine());
            var exsistProduct = _unitOfWork.Sellers.GetAll().FirstOrDefault(c => c.Id == id);
            if (exsistProduct is null) 
            {
                Console.WriteLine("Product not found!");
                return;
            }
            _unitOfWork.Sellers.Delete(exsistProduct);
            _unitOfWork.Commit();   
        }

        public void Exit()
        {
            return;
        }

        public void GetProductsWithFilter()
        {
            throw new NotImplementedException();
        }

        public void GetSoldProducts()
        {
            throw new NotImplementedException();
        }

        public void GetSoldProductsWithGivenDate()
        {
            throw new NotImplementedException();
        }

        public void GetTotalIncome()
        {
            throw new NotImplementedException();
        }

        public void UpdateCountOfProduct()
        {
            throw new NotImplementedException();
        }
    }
}
