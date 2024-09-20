using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopWeb.Data.DTO.CustomersDTO;
using ShopWeb.Data.Interfaces;

namespace ShopWeb.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomers CustomersDb;
        public CustomersController(ICustomers customersDB)
        {
            this.CustomersDb = customersDB;
        }

        // GET: CustomersController
        public ActionResult Index()
        {
            var customers = this.CustomersDb.GetAllCustomers();
            return View(customers);
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {
            var customers = this.CustomersDb.GetCustomersById(id);
            return View(customers);
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomersAddDTO addDTO)
        {
            try
            {
                addDTO.creation_date = DateTime.Now;
                addDTO.creation_user = 2;
                this.CustomersDb.SaveCustomers(addDTO);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            var customers = this.CustomersDb.GetCustomersById(id);
            return View(customers);
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomersUpdateDTO customersUpdateDTO)
        {
            try
            {
                customersUpdateDTO.modify_date = DateTime.Now;
                customersUpdateDTO.modify_user = 2;
                this.CustomersDb.UpdateCustomers(customersUpdateDTO);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        }
    }

