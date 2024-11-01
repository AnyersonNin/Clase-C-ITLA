using ShopWeb.Data.DTO.CategoriesDTO;

namespace ShopWeb.Data.Interfaces
{
    public interface ICategories
    {
        void SaveCategories(CategoriesAddDTO categoriesAddDTO);
        void RemoveCategories(CategoriesRemoveDTO categoriesRemoveDTO);
        void UpdateCategories(CategoriesUpdateDTO categoriesUpdateDTO); 
        List<CategoriesAddDTO> GetAllCategories();

        CategoriesAddDTO GetCategoryById(int categoryid);
    }
}
