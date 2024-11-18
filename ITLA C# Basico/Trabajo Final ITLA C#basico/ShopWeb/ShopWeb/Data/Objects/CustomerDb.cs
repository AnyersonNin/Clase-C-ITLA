
using ShopWeb.Data.Entities;
using ShopWeb.Data.Interfaces;
using ShopWeb.Data.Models;

namespace ShopWeb.Data.Objects
{
    public class CustomerDb : IBaseReposity<Customers, CustomerResult,List<CustomerResult>>
    {
        private readonly List<Customers> _customers;

        public CustomerDb(List<Customers> customers)
        {
           this._customers = customers;
        }

        public async Task<bool> Exists(Func<Customers, bool> filtrer)
        {
          var result = this._customers.Any(filtrer);
          return await Task.FromResult(result);
        }

        public async Task<List<CustomerResult>> GetAll()
        {
            List<CustomerResult> customerResults = new List<CustomerResult>();

            customerResults = this._customers.Select(x => new CustomerResult()
            {
             custid = x.custid,
             companyname = x.companyname,
             contacttitle = x.contacttitle,
             address = x.address,
             email = x.email,
             city = x.city,
             region = x.region,
             postalcode = x.postalcode,
             country = x.country,
             phone = x.phone,
             fax = x.fax,
             creation_date = x.creation_date,
             creation_user = x.creation_user,
            }).ToList();

            return await Task.FromResult<List<CustomerResult>>(customerResults);
        }

        public async Task<List<CustomerResult>> GetAll(Func<Customers, bool> filtrer)
        {
            List<CustomerResult> customerResults = new List<CustomerResult>();

            customerResults = this._customers.Where(filtrer).Select(x => new CustomerResult()
            {
                custid = x.custid,
                companyname = x.companyname,
                contacttitle = x.contacttitle,
                address = x.address,
                email = x.email,
                city = x.city,
                region = x.region,
                postalcode = x.postalcode,
                country = x.country,
                phone = x.phone,
                fax = x.fax,
                creation_date = x.creation_date,
                creation_user = x.creation_user,
            }).ToList();

            return await Task.FromResult<List<CustomerResult>>(customerResults);
        }

        public async Task<CustomerResult> GetEntityBy(int Id)
        {
           CustomerResult customerResult = new CustomerResult();

           var customer = this._customers.FirstOrDefault(x => x.custid == Id);

            customerResult.custid = customer.custid;
            customerResult.companyname = customer.companyname;
            customerResult.contacttitle = customer.contacttitle;
            customerResult.address = customer.address;
            customerResult.email = customer.email;
            customerResult.city = customer.city;
            customerResult.region = customer.region;
            customerResult.postalcode = customer.postalcode;
            customerResult.country = customer.country;
            customerResult.phone = customer.phone;
            customerResult.fax = customer.fax;
            customerResult.creation_user = customer.creation_user;
            customerResult.creation_date = customer.creation_date;
           
           return await Task.FromResult<CustomerResult>(customerResult);
        }

        public async Task<CustomerResult> Remove(Customers entity)
        {
            CustomerResult customerResult = new CustomerResult();

            var customer = this._customers.FirstOrDefault(x => x.custid == entity.custid);

            if (customer != null)
            {
                this._customers.Remove(customer);
            }
            return await Task.FromResult(customerResult);
        }

        public async Task<CustomerResult> Save(Customers entity)
        {
            CustomerResult customerResult = new CustomerResult();
            this._customers.Add(entity);
            return await Task.FromResult(customerResult);
        }

        public async Task<CustomerResult> Update(Customers entity)
        {
          CustomerResult customersResult = new CustomerResult();

            await this.Remove(entity);

            await this.Save(entity);

            return await Task.FromResult(customersResult);
        }
    }
}
