using ShopWeb.Data.Context;
using ShopWeb.Data.DTO.CategoriesDTO;
using ShopWeb.Data.DTO.ProducsDTO;
using ShopWeb.Data.Entities;
using ShopWeb.Data.Exceptions;
using ShopWeb.Data.Interfaces;

namespace ShopWeb.Data.Daos
{
    public class DaoCategories : ICategories
    {
        private readonly ShopDbContext _shopDb;
        private readonly ILogger<DaoCategories> logger;

        public DaoCategories(ShopDbContext shopDbContext, ILogger<DaoCategories> logger)
        {
            this._shopDb = shopDbContext;
            this.logger = logger;
        }
        public CategoriesAddDTO GetCategoryById(int categoriesid)
        {
            CategoriesAddDTO categoryResult = new CategoriesAddDTO();

            try
            {
                var categorie = this._shopDb.Categories.Find(categoriesid);

                if (categorie is null)
                    throw new CategoriesExceptions("La categoria no es valida");
                categoryResult.categoryid = categorie.categoryid;
                categoryResult.categoryname = categorie.categoryname;
                categoryResult.description = categorie.description;
                categoryResult.creation_date = categorie.creation_date;
                categoryResult.creation_user = categorie.creation_user;

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error obteniendo la categoria", ex.ToString());
            }

            return categoryResult;
        }
        public List<CategoriesAddDTO> GetAllCategories()
        {
            List<CategoriesAddDTO> categories = new List<CategoriesAddDTO>();
            try
            {
                categories = (from categorie in this._shopDb.Categories
                              where categorie.deleted == false
                              select new CategoriesAddDTO()
                              {
                                  categoryid = categorie.categoryid,
                                  categoryname = categorie.categoryname,
                                  description = categorie.description,
                                  creation_user = categorie.creation_user,
                                  creation_date = categorie.creation_date,
                              }).ToList();

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error obteniendo los Productos", ex.ToString());
            }
            return categories;
        }
        public void RemoveCategories(CategoriesRemoveDTO categoriesRemoveDTO)
        {
            try
            {
                var categorie = this._shopDb.Categories.Find(categoriesRemoveDTO.categoryid);
                if (categoriesRemoveDTO is null)
                    throw new ProductsExceptions("La categoria no puede ser nulo");


                if (categorie is null)
                    throw new ProductsExceptions("La categoria no esta Disponible");

                categorie.deleted = true;
                categorie.delete_date = categoriesRemoveDTO?.delete_date;
                categorie.delete_user = categoriesRemoveDTO?.delete_user;
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error Removiendo el Producto", ex.ToString());
            }
        }

        public void SaveCategories(CategoriesAddDTO categoriesAddDTO)
        {
            try
            {
                if (categoriesAddDTO is null)
                    throw new CategoriesExceptions("La categoria no puede ser nula");

                if (this._shopDb.Categories.Any(categorie => categorie.categoryname == categoriesAddDTO.categoryname))
                    throw new CategoriesExceptions("la categoria esta registrada");

                Categories categories = new Categories()
                {
                    categoryname = categoriesAddDTO.categoryname,
                    description = categoriesAddDTO.description,
                    creation_date = categoriesAddDTO.creation_date,
                    creation_user = categoriesAddDTO.creation_user,

                };
                this._shopDb.Categories.Add(categories);
                this._shopDb.SaveChanges();

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error guardando la categoria", ex.ToString());
            }

        }

        public void UpdateCategories(CategoriesUpdateDTO categoriesUpdateDTO)
        {
            try
            {
                if (categoriesUpdateDTO is null)
                    throw new CategoriesExceptions("La categoria no puede ser nula");

                Categories categories = this._shopDb.Categories.Find(categoriesUpdateDTO.categoryid);

                if (categories is null)
                    throw new CategoriesExceptions("La categoria no esta Disponible");

                categories.categoryid = categoriesUpdateDTO.categoryid;
                categories.categoryname = categoriesUpdateDTO.categoryname;
                categories.description = categoriesUpdateDTO.description;
                categories.modify_user = categoriesUpdateDTO.modify_user;
                categories.modify_date = categoriesUpdateDTO.modify_date;

                this._shopDb.Categories.Update(categories);
                this._shopDb.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error actualizando la categoria", ex.ToString());
            }
        }
    } 
}
