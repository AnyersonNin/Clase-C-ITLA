using ShopWeb.Data.Base;
using ShopWeb.Data.Class;
using ShopWeb.Data.Entities;
using ShopWeb.Data.Interfaces;
using ShopWeb.Data.Models;
using System.Linq.Expressions;

namespace ShopWeb.Data.Objects
{
    public class ProductsDb : IBaseReposity<Products, ProductsResult,List<ProductsResult>>
    {
        private readonly List<Products> _products;

        public ProductsDb(List<Products>products)
        {
          this._products = products;
        }

        public async Task<bool> Exists(Func<Products, bool> filtrer)
        {
           var result = this._products.Any(filtrer);

           return await Task.FromResult(result);
        }

        public async Task<List<ProductsResult>> GetAll()
        {
            List<ProductsResult> productsResult = new List<ProductsResult>();

            productsResult = this._products.Select(x => new ProductsResult()
            {   
              productid = x.productid,
              productname = x.productname,
              categoryid = x.categoryid,
              supplierid = x.supplierid,
              unitprice = x.unitprice,
              discontinued = x.discontinued,
              creation_date = x.creation_date,
              creation_user = x.creation_user,
                              
            }).ToList();

            return await Task.FromResult<List<ProductsResult>>(productsResult);
        }

        public async Task<List<ProductsResult>> GetAll(Func<Products, bool> filtrer)
        {
            List<ProductsResult> productsResult = new List<ProductsResult>();

            productsResult = this._products.Where(filtrer).Select(x => new ProductsResult()
            {
                productid = x.productid,
                productname = x.productname,
                categoryid = x.categoryid,
                supplierid = x.supplierid,
                unitprice = x.unitprice,
                discontinued = x.discontinued,
                creation_date = x.creation_date,
                creation_user = x.creation_user,

            }).ToList();

            return await Task.FromResult<List<ProductsResult>>(productsResult);
        }

        public async Task<ProductsResult> GetEntityBy(int Id)
        {
          ProductsResult productsResult = new ProductsResult();

            var product = this._products.FirstOrDefault(x => x.productid == Id);

            productsResult.productid = product.productid;
            productsResult.productname = product.productname;
            productsResult.categoryid = product.categoryid;
            productsResult.supplierid = product.supplierid;
            productsResult.unitprice = product.unitprice;
            productsResult.discontinued = product.discontinued;
            productsResult.creation_user = product.creation_user;
            productsResult.creation_date = product.creation_date;

            return await Task.FromResult<ProductsResult>(productsResult);

        }

        public async Task<ProductsResult> Remove(Products entity)
        {
            ProductsResult productsResult = new ProductsResult();
            
            var product = this._products.FirstOrDefault(x => x.productid == entity.productid);
            if (product != null) 
            {
             this._products.Remove(product);
            }

            return await Task.FromResult(productsResult);
        }

        public async Task<ProductsResult> Save(Products entity)
        {
           ProductsResult productsResult = new ProductsResult();
           this._products.Add(entity);
           return await Task.FromResult(productsResult);
        }

        public async Task<ProductsResult> Update(Products entity)
        {
           ProductsResult productsResult = new ProductsResult();

            await this.Remove(entity);

            await this.Save(entity);

            return await Task.FromResult(productsResult);
        }
    }
}
