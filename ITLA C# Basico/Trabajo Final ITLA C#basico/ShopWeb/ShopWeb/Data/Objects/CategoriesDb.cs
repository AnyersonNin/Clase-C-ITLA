using ShopWeb.Data.Entities;
using ShopWeb.Data.Interfaces;
using ShopWeb.Data.Models;

namespace ShopWeb.Data.Objects
{
    public class CategoriesDb : IBaseReposity<Categories, CategoriesResult, List<CategoriesResult>>
    {
        private readonly List<Categories> _categories;

        public CategoriesDb(List<Categories> categories)
        {
            this._categories = categories;
        }

        public async Task<bool> Exists(Func<Categories, bool> filter)
        {
            try
            {
                var result = this._categories.Any(filter);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Exists: {ex.Message}");
                return await Task.FromResult(false);
            }
        }

        public async Task<List<CategoriesResult>> GetAll()
        {
            try
            {
                var categoriesResults = this._categories.Select(x => new CategoriesResult
                {
                    categoryid = x.categoryid,
                    categoryname = x.categoryname,
                    description = x.description,
                    creation_date = x.creation_date,
                    creation_user = x.creation_user,
                }).ToList();

                return await Task.FromResult(categoriesResults);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAll: {ex.Message}");
                return await Task.FromResult(new List<CategoriesResult>());
            }
        }

        public async Task<List<CategoriesResult>> GetAll(Func<Categories, bool> filter)
        {
            try
            {
                var categoriesResults = this._categories.Where(filter).Select(x => new CategoriesResult
                {
                    categoryid = x.categoryid,
                    categoryname = x.categoryname,
                    description = x.description,
                    creation_date = x.creation_date,
                    creation_user = x.creation_user,
                }).ToList();

                return await Task.FromResult(categoriesResults);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAll con filter: {ex.Message}");
                return await Task.FromResult(new List<CategoriesResult>());
            }
        }

        public async Task<CategoriesResult> GetEntityBy(int id)
        {
            try
            {
                var category = this._categories.FirstOrDefault(x => x.categoryid == id);

                if (category == null)
                {
                    Console.WriteLine($"Category en ID {id} no existe.");
                    return null;
                }

                var categoriesResult = new CategoriesResult
                {
                    categoryid = category.categoryid,
                    categoryname = category.categoryname,
                    description = category.description,
                    creation_date = category.creation_date,
                    creation_user = category.creation_user,
                };

                return await Task.FromResult(categoriesResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetEntityBy: {ex.Message}");
                return null;
            }
        }

        public async Task<CategoriesResult> Remove(Categories entity)
        {
            try
            {
                var category = this._categories.FirstOrDefault(x => x.categoryid == entity.categoryid);

                if (category != null)
                {
                    this._categories.Remove(category);

                    var categoriesResult = new CategoriesResult
                    {
                        categoryid = category.categoryid,
                        categoryname = category.categoryname,
                        description = category.description,
                        deleted = category.deleted = true,
                        delete_date = DateTime.Now,
                        delete_user = category.delete_user,
                    };

                    return await Task.FromResult(categoriesResult);
                }

                Console.WriteLine($"Category con ID {entity.categoryid} no se cuentra para removido.");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Remove: {ex.Message}");
                return null;
            }
        }

        public Task<CategoriesResult> Save(Categories entity)
        {
            try
            {
                this._categories.Add(entity);

                var categoriesResult = new CategoriesResult
                {
                    categoryid = entity.categoryid,
                    categoryname = entity.categoryname,
                    description = entity.description,
                    creation_date = entity.creation_date,
                    creation_user = entity.creation_user,
                };

                return Task.FromResult(categoriesResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Save: {ex.Message}");
                return Task.FromResult<CategoriesResult>(null);
            }
        }

        public async Task<CategoriesResult> Update(Categories entity)
        {
            try
            {
                var existing = this._categories.FirstOrDefault(x => x.categoryid == entity.categoryid);

                if (existing == null)
                {
                    Console.WriteLine($"Category con ID {entity.categoryid}no se cuentra para update.");
                    return null;
                }

                existing.categoryname = entity.categoryname;
                existing.description = entity.description;
                existing.modify_date = DateTime.Now;
                existing.modify_user = entity.modify_user;

                var categoriesResult = new CategoriesResult
                {
                    categoryid = existing.categoryid,
                    categoryname = existing.categoryname,
                    description = existing.description,
                    modify_date = existing.modify_date,
                    modify_user = existing.modify_user,
                };

                return await Task.FromResult(categoriesResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Update: {ex.Message}");
                return null;
            }
        }
    }
}