using ShopWeb.Data.DTO;
using ShopWeb.Data.DTO.ProducsDTO;

namespace ShopWeb.Data.Interfaces
{
    public interface IProducts
    {
        void SaveProducts(ProductsAddDTO productsAddDTO);

        void RemoveProducts(ProductsRemoveDTO productsRemoveDTO);

        void UpdateProducts(ProductsUpdateDTO productsUpdateDTO);

        List<ProductsAddDTO> GetProducts();

        ProductsAddDTO GetProductById(int productid );

    }
}
