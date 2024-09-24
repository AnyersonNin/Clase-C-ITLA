using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopWeb.Data.DTO.SuppliersDTO;
using ShopWeb.Data.Interfaces;

namespace ShopWeb.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISuppliers SuppliersDb;

        public SuppliersController(ISuppliers suppliersDb)
        {
            this.SuppliersDb = suppliersDb;
        }

        // GET: SuppliersController
        public ActionResult Index()
        {
            var suppliers = this.SuppliersDb.GetSuppliers();
            return View(suppliers);
        }

        // GET: SuppliersController/Details/5
        public ActionResult Details(int id)
        {
            var suppliers = SuppliersDb.GetSuppliersById(id);
            return View(suppliers);
        }

        // GET: SuppliersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuppliersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuppliersAddDTO addDTO)
        {
            try
            {
                addDTO.creation_date = DateTime.Now;
                addDTO.creation_user = 2;

                this.SuppliersDb.SaveSuppliers(addDTO);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuppliersController/Edit/5
        public ActionResult Edit(int id)
        {
            var suppliers = this.SuppliersDb.GetSuppliersById (id);
            return View(suppliers);
        }

        // POST: SuppliersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SuppliersUpdateDTO updateDTO)
        {
            try
            {
                updateDTO.modify_date = DateTime.Now;
                updateDTO.modify_user = 2;
                this.SuppliersDb.UpdateSuppliers(updateDTO);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
