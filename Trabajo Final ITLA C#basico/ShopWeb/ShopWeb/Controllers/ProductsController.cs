using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopWeb.Data.DTO;
using ShopWeb.Data.DTO.ProducsDTO;
using ShopWeb.Data.Interfaces;

namespace ShopWeb.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProducts ProductDb;

        public ProductsController(IProducts productDb)
        {
            this.ProductDb = productDb;
        }

        // GET: ProductsController
        public ActionResult Index()
        { 
            var products = this.ProductDb.GetProducts();
            return View(products);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
          var products = this.ProductDb.GetProductById(id);
            return View(products);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductsAddDTO AddDTO)
        {
            try
            {
                AddDTO.creation_date = DateTime.Now;
                AddDTO.creation_user = 2;

                this.ProductDb.SaveProducts(AddDTO);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            var products = this.ProductDb.GetProductById(id);
            return View(products);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductsUpdateDTO updateDTO)
        {
            try
            {
                updateDTO.modify_date = DateTime.Now;
                updateDTO.modify_user = 2;
                this.ProductDb.UpdateProducts(updateDTO);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
