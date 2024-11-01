using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopWeb.Data.DTO.CategoriesDTO;
using ShopWeb.Data.Interfaces;

namespace ShopWeb.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategories CategoriesDb;

        public CategoriesController(ICategories categoriesDb)
        {
            this.CategoriesDb = categoriesDb;
        }
        // GET: CategoriesController
        public ActionResult Index()
        {
            var categories = this.CategoriesDb.GetAllCategories();
            return View(categories);
        }

        // GET: CategoriesController/Details/5
        public ActionResult Details(int id)
        {
            var categorie = this.CategoriesDb.GetCategoryById(id);
            return View(categorie);
        }

        // GET: CategoriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriesAddDTO AddDTO)
        {
            try
            {
                AddDTO.creation_date = DateTime.Now;
                AddDTO.creation_user = 2;

                this.CategoriesDb.SaveCategories(AddDTO);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController/Edit/5
        public ActionResult Edit(int id)
        {
            var categories = this.CategoriesDb.GetCategoryById (id);
            return View(categories);
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoriesUpdateDTO updateDTO)
        {
            try
            {
                updateDTO.modify_date = DateTime.Now;
                updateDTO.modify_user = 2;
                this.CategoriesDb.UpdateCategories(updateDTO);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
       
    }
}
