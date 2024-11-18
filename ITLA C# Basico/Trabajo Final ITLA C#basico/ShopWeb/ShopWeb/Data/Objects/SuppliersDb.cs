using ShopWeb.Data.Base;
using ShopWeb.Data.Class;
using ShopWeb.Data.DTO.SuppliersDTO;
using ShopWeb.Data.Entities;
using ShopWeb.Data.Interfaces;
using ShopWeb.Data.Models;
using System.Linq.Expressions;

namespace ShopWeb.Data.Objects
{
    public class SuppliersDb : IBaseReposity <Suppliers, SuppliersResult,List<SuppliersResult>>
    {
        private readonly List<Suppliers> _suppliers;

        public SuppliersDb(List<Suppliers>suppliers)
        {
           this._suppliers = suppliers;
        }

        public async Task<bool> Exists(Func<Suppliers, bool> filtrer)
        {
           var result = this._suppliers.Any(filtrer);
            return await Task.FromResult(result);
        }

        public async Task<List<SuppliersResult>> GetAll()
        {
          List<SuppliersResult> suppliersResult = new List<SuppliersResult>();

             suppliersResult = this._suppliers.Select(x => new SuppliersResult()
            {
             supplierid = x.supplierid,
             companyname = x.companyname,
             contacttitle = x.contacttitle,
             address = x.address,
             city = x.city,
             region = x.region,
             postalcode = x.postalcode,
             country = x.country,
             phone = x.phone,
             fax = x.fax,
             creation_date = x.creation_date,
             creation_user = x.creation_user,
            }).ToList();

            return await Task.FromResult<List<SuppliersResult>>(suppliersResult);
        }

        public async Task<List<SuppliersResult>> GetAll(Func<Suppliers, bool> filtrer)
        {
            List<SuppliersResult> suppliersResults = new List<SuppliersResult>();

            suppliersResults = this._suppliers.Where(filtrer).Select(x => new SuppliersResult()
            {
                supplierid = x.supplierid,
                companyname = x.companyname,
                contacttitle = x.contacttitle,
                address = x.address,
                city = x.city,
                region = x.region,
                postalcode = x.postalcode,
                country = x.country,
                phone = x.phone,
                fax = x.fax,
                creation_date = x.creation_date,
                creation_user = x.creation_user,
            }).ToList();

            return await Task.FromResult<List<SuppliersResult>>(suppliersResults);

        }

        public async Task<SuppliersResult> GetEntityBy(int Id)
        {
           SuppliersResult suppliersResult = new SuppliersResult();

            var suppliers = this._suppliers.FirstOrDefault(x => x.supplierid == Id);

            suppliersResult.supplierid = suppliers.supplierid;
            suppliersResult.companyname = suppliers.companyname;
            suppliersResult.contacttitle = suppliers.contacttitle;
            suppliersResult.address = suppliers.address;
            suppliersResult.city = suppliers.city;
            suppliersResult.region = suppliers.region;
            suppliersResult.postalcode = suppliers.postalcode;
            suppliersResult.country = suppliers.country;
            suppliersResult.phone = suppliers.phone;
            suppliersResult.fax = suppliers.fax;
            suppliersResult.creation_user = suppliers.creation_user;
            suppliersResult.creation_date = suppliers.creation_date;

            return await Task.FromResult<SuppliersResult>(suppliersResult);

        }

        public async Task<SuppliersResult> Remove(Suppliers entity)
        {
            SuppliersResult suppliersResult = new SuppliersResult();

            var suppliers = this._suppliers.FirstOrDefault(x => x.supplierid == entity.supplierid);

            if(suppliers != null) 
            { 
              this._suppliers.Remove(entity);
            }

            return await Task.FromResult(suppliersResult);
        }

        public async Task<SuppliersResult> Save(Suppliers entity)
        {
            SuppliersResult suppliersResult = new SuppliersResult();

            this._suppliers.Add(entity);
            return await Task.FromResult(suppliersResult);
        }

        public async Task<SuppliersResult> Update(Suppliers entity)
        {
            SuppliersResult suppliersResult = new SuppliersResult();

            await this.Remove(entity);
            await this.Save(entity);

            return await Task.FromResult(suppliersResult);
        }
    }
}
