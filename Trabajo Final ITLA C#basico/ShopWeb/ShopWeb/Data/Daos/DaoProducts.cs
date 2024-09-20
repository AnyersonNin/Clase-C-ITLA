 using ShopWeb.Data.Context;
using ShopWeb.Data.DTO;
using ShopWeb.Data.DTO.ProducsDTO;
using ShopWeb.Data.Entities;
using ShopWeb.Data.Exceptions;
using ShopWeb.Data.Interfaces;
using System.Collections.Generic;

namespace ShopWeb.Data.Daos
{
    public class DaoProducts : IProducts
    {
        private readonly ShopDbContext _shopDb;
        private readonly ILogger<DaoProducts> logger;

        public DaoProducts(ShopDbContext shopDbContext,ILogger<DaoProducts> logger)
        {
            this._shopDb= shopDbContext;
            this.logger = logger;
        }
        public ProductsAddDTO GetProductById(int productid)
        {
            ProductsAddDTO productResult = new ProductsAddDTO();
            try
            {
             var product = this._shopDb.Products.Find(productid);

                if (product is null)
                    throw new ProductsExceptions("El Producto no es valido");
                
                productResult.productid = product.productid;
                productResult.productname = product.productname;
                productResult.categoryid = product.categoryid;
                productResult.unitprice = product.unitprice;
                productResult.discontinued = product.discontinued;

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error obteniendo el producto", ex.ToString());
            }

            return productResult;

        }

        public List<ProductsAddDTO> GetProducts()
        {
            List <ProductsAddDTO> products = new List <ProductsAddDTO>();
            try
            {
                 products = (from product in this._shopDb.Products 
                            where product.deleted == false 
                            select new ProductsAddDTO() 
                            {
                             productid = product.productid,
                             productname = product.productname,
                             categoryid = product.categoryid,
                             unitprice = product.unitprice,
                             discontinued = product.discontinued,
                            }).ToList();
            }
            catch (Exception ex) 
            {
               this.logger.LogError("Error obteniendo los Productos", ex.ToString());
            }

            return products;
        }

        public void RemoveProducts(ProductsRemoveDTO productsRemoveDTO)
        {

            try
            {
                var product = this._shopDb.Products.Find(productsRemoveDTO.productid);

                if (productsRemoveDTO is null)
                    throw new ProductsExceptions("El Producto no puede ser nulo");
                

                if (product is null)
                    throw new ProductsExceptions("El Producto no esta Disponible");

                product.deleted = true;
                product.delete_date = productsRemoveDTO?.delete_date;
                product.delete_user = productsRemoveDTO?.delete_user;
            }
            catch (Exception ex) 
            {
                this.logger.LogError("Error Removiendo el Producto", ex.ToString());
            }

        }

        public void SaveProducts(ProductsAddDTO productsAddDTO)
        {
            try 
            {
                if (productsAddDTO is null)
                    throw new ProductsExceptions("El Producto no puede ser nulo");

                if(this._shopDb.Products.Any(product => product.productname == productsAddDTO.productname))
                    throw new ProductsExceptions("El Producto esta registrado");

                Products products = new Products()
                { 
                productid = productsAddDTO.productid,
                 productname = productsAddDTO.productname,
                 categoryid = productsAddDTO.categoryid,
                 unitprice = productsAddDTO.unitprice,
                 discontinued = productsAddDTO.discontinued,
             
                };
                this._shopDb.Products.Add(products);
                this._shopDb.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error guardando el Productos", ex.ToString());
            }
        }

        public void UpdateProducts(ProductsUpdateDTO productsUpdateDTO)
        {
            try
            {
                if (productsUpdateDTO is null)
                    throw new ProductsExceptions("El Producto no puede ser nulo");

                Products products = this._shopDb.Products.Find(productsUpdateDTO.productid);
                
                if (products is null)
                    throw new ProductsExceptions("El Producto no esta Disponible");

                products.productname = productsUpdateDTO.productname;
                products.categoryid = productsUpdateDTO.categoryid;
                products.supplierid = productsUpdateDTO.supplierid;
                products.unitprice = productsUpdateDTO.unitprice;
                products.discontinued = productsUpdateDTO.discontinued;
                products.modify_user = productsUpdateDTO.modify_user;
                products.modify_date = productsUpdateDTO.modify_date;

                this._shopDb.Products.Update(products);
                this._shopDb.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error actualizando el Productos", ex.ToString());
            }
        }
    }
}
