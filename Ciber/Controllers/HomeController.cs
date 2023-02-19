using Ciber.Models;
using Ciber.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _config;

        public IConfiguration Configuration { get; }
        private string generatedToken = null;

        public HomeController(ILogger<HomeController> logger, IProductRepository productRepository, ICustomerRepository customerRepository, IOrderRepository orderRepository, ITokenService tokenService, IUserRepository userRepository, IConfiguration config)
        {
            _logger = logger;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _tokenService = tokenService;
            _userRepository = userRepository;
            _config = config;

        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody]UserModel userModel)
        {
            if (string.IsNullOrEmpty(userModel.UserName) || string.IsNullOrEmpty(userModel.Password))
            {
                return (RedirectToAction("Error"));
            }
            IActionResult response = Unauthorized();
            var validUser = GetUser(userModel);

            if (validUser != null)
            {
                generatedToken = _tokenService.BuildToken(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(), validUser);
                if (generatedToken != null)
                {
                    HttpContext.Session.SetString("Token", generatedToken);
                    return RedirectToAction("MainWindow");
                }
                else
                {
                    return (RedirectToAction("Error"));
                }
            }
            else
            {
                return (RedirectToAction("Error"));
            }
        }

        private UserDTO GetUser(UserModel userModel)
        {
            // Write your code here to authenticate the user     
            return _userRepository.GetUser(userModel);
        }

        [Authorize]
        [Route("mainwindow")]
        [HttpGet]
        public IActionResult MainWindow()
        {
            string token = HttpContext.Session.GetString("Token");
            if (token == null)
            {
                return (RedirectToAction("Index"));
            }
            if (!_tokenService.ValidateToken(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(), token))
            {
                return (RedirectToAction("Index"));
            }
            ViewBag.Message = BuildMessage(token, 50);
            return View();
        }

        public IActionResult Error()
        {
            ViewBag.Message = "An error occured...";
            return View();
        }

        private string BuildMessage(string stringToSplit, int chunkSize)
        {
            var data = Enumerable.Range(0, stringToSplit.Length / chunkSize).Select(i => stringToSplit.Substring(i * chunkSize, chunkSize));
            string result = "The generated token is:";
            foreach (string str in data)
            {
                result += Environment.NewLine + str;
            }
            return result;
        }

        public IActionResult Index(string sortOrder, string txtSearch, int? page)
        {
            try
            {
                ViewBag.ProductNameSortParm = sortOrder == "Product" ? "product_desc" : "Product";
                ViewBag.CategorySortParm = sortOrder == "Category" ? "category_desc" : "Category";
                ViewBag.CustomerSortParm = sortOrder == "Customer" ? "customer_desc" : "Customer";

                if (page > 0)
                {
                    page = page;
                }
                else
                {
                    page = 1;
                }


                ViewBag.TxtSearch = txtSearch;
                int pageSize = 5;
                int pageIndex = (page ?? 1);
                // lấy dữ liệu đơn hàng
                OrderModel orderModel = new OrderModel();
                orderModel.ListOrder = new List<OrderDetail>();
                PagingParam paging = new PagingParam()
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    TxtSearch = txtSearch
                };
                var result = _orderRepository.GetOrderDetailsPaging(paging);
                orderModel.ListOrder = result.Item1;
                // sort dữ liệu
                switch (sortOrder)
                {
                    case "product_desc":
                        orderModel.ListOrder = orderModel.ListOrder.OrderByDescending(s => s.ProductName).ToList();
                        break;
                    case "Category":
                        orderModel.ListOrder = orderModel.ListOrder.OrderBy(s => s.CategoryName).ToList();
                        break;
                    case "category_desc":
                        orderModel.ListOrder = orderModel.ListOrder.OrderByDescending(s => s.CategoryName).ToList();
                        break;
                    case "Customer":
                        orderModel.ListOrder = orderModel.ListOrder.OrderBy(s => s.CustomerName).ToList();
                        break;
                    case "customer_desc":
                        orderModel.ListOrder = orderModel.ListOrder.OrderByDescending(s => s.CustomerName).ToList();
                        break;
                    case "Product":
                        orderModel.ListOrder = orderModel.ListOrder.OrderBy(s => s.ProductName).ToList();
                        break;
                    default:
                        orderModel.ListOrder = orderModel.ListOrder.OrderByDescending(s => s.OrderDate).ToList();
                        break;
                }

                paging.TotalPage = (int)Math.Ceiling((decimal)result.Item2 / pageSize);
                // thông tin phân trang
                ViewBag.Paging = paging;

                // lấy dữ liệu sản phẩm
                List<Product> products = new List<Product>();
                products = _productRepository.GetProducts();
                List<SelectListItem> lstProduct = new List<SelectListItem>();

                foreach (Product item in products)
                {
                    lstProduct.Add(new SelectListItem
                    {
                        Text = item.ProductName,
                        Value = item.ProductID.ToString()
                    });
                }
                ViewBag.products = lstProduct;

                // lấy dữ liệu người dùng
                List<Customer> customers= new List<Customer>();
                customers = _customerRepository.GetCustomers();
                List<SelectListItem> lstCustomer = new List<SelectListItem>();

                foreach (Customer item in customers)
                {
                    lstCustomer.Add(new SelectListItem
                    {
                        Text = item.CustomerName,
                        Value = item.CustomerID.ToString()
                    });
                }
                ViewBag.customers = lstCustomer;
                return View(orderModel);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveOrder()
        {
            Orders order = new Orders();
            var a = HttpContext.Request.Form;
            // tên đơn hàng
            order.OrderName = HttpContext.Request.Form["txtOrderName"].ToString();
            // ID khách hàng
            string txtCustomerID = HttpContext.Request.Form["customers"].ToString();
            long.TryParse(txtCustomerID, out long customerID);
            order.CustomerID = customerID;
            // ID sản phẩm
            string txtProductID = HttpContext.Request.Form["products"].ToString();
            long.TryParse(txtProductID, out long productID);
            order.ProductID = productID;
            // Số lượng hàng đặt
            string txtAmount = HttpContext.Request.Form["txtAmount"].ToString();
            int.TryParse(txtAmount, out int amount);
            order.Amount = amount;
            // Ngày đặt hàng
            string txtOrderDate = HttpContext.Request.Form["orderDate"].ToString();
            DateTime.TryParse(txtOrderDate, out DateTime orderDate);
            order.OrderDate = orderDate;

            // lưu đơn hàng xuống db
            var result = _orderRepository.CreateOrder(order);
            //umodel.Name = HttpContext.Request.Form["txtName"].ToString();
            //umodel.Age = Convert.ToInt32(HttpContext.Request.Form["txtAge"]);
            //umodel.City = HttpContext.Request.Form["txtCity"].ToString();
            //int result = umodel.SaveDetails();
            if (result > 0)
            {
                ViewBag.Result = "Data Saved Successfully";
            }
            else
            {
                ViewBag.Result = "Something Went Wrong";
            }
            return Redirect("Index");
        }
    }
}
