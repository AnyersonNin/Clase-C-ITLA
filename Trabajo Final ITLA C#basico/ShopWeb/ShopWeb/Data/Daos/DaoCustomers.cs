using ShopWeb.Data.Context;
using ShopWeb.Data.DTO.CustomersDTO;
using ShopWeb.Data.Entities;
using ShopWeb.Data.Exceptions;
using ShopWeb.Data.Interfaces;

namespace ShopWeb.Data.Daos
{
    public class DaoCustomers : ICustomers
    {
        private readonly ShopDbContext _shopDb;
        private readonly ILogger<DaoCustomers> logger;

        public DaoCustomers(ShopDbContext shopDbContext, ILogger<DaoCustomers> logger)
        {
            this._shopDb = shopDbContext;
            this.logger = logger;
        }
        public CustomersAddDTO GetCustomersById (int customerid)
        {
          CustomersAddDTO customersResult = new CustomersAddDTO();
            try 
            { 
             var customer = this._shopDb.Customers.Find(customerid);

             if(customer is null)
                    throw new CustomersExceptions("El Cliente no es valido");
              
             customersResult.custid = customer.custid;
             customersResult.companyname = customer.companyname;
             customersResult.contactname = customer.contactname;
             customersResult.contacttitle = customer.contacttitle;
             customersResult.address = customer.address;
             customersResult.email = customer.email;
             customersResult.city = customer.city;
             customersResult.region = customer.region;
             customersResult.postalcode = customer.postalcode;
             customersResult.country = customer.country;
             customersResult.phone = customer.phone;
             customersResult.fax = customer.fax;
             customersResult.creation_user = customer.creation_user;
             customersResult.creation_date = customer.creation_date;
                        
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error obteniendo el Consumidor", ex.ToString());
            }

            return customersResult;
        }
        public List<CustomersAddDTO> GetAllCustomers()
        {
            List<CustomersAddDTO> customers = new List<CustomersAddDTO>();
         try
         {
            customers = (from customer in this._shopDb.Customers
                        where customer.deleted == false
                        select new CustomersAddDTO()
                        {
                          custid = customer.custid,
                          companyname = customer.companyname,
                          contactname = customer.contactname,
                          contacttitle = customer.contacttitle,
                          address = customer.address,
                          email = customer.email,
                          city = customer.city,
                          region = customer.region,
                          postalcode = customer.postalcode,
                          country = customer.country,
                          phone = customer.phone,
                          fax = customer.fax,
                          creation_user = customer.creation_user,
                          creation_date = customer.creation_date,
                         
                        }).ToList();

         }
            catch (Exception ex)
            {
                this.logger.LogError("Error obteniendo el Cliente", ex.ToString());
            }

            return customers;

        }

        public void RemoveCustomers(CustomersRemoveDTO customersRemoveDTO)
        {
         try
         { 
          var customers = this._shopDb.Customers.Find(customersRemoveDTO.custid);
                if (customersRemoveDTO is null)
                    throw new CustomersExceptions("El cliente no puede ser nulo");
                if(customers is null)
                    throw new CustomersExceptions("El cliente no esta Disponible");
           
                customers.deleted = true;   
                customers.delete_date = customersRemoveDTO.delete_date;
                customers.delete_user = customersRemoveDTO.delete_user;
         }
         catch (Exception ex)
         {
           this.logger.LogError("Error Removiendo el Cliente", ex.ToString());
         }

        }

        public void SaveCustomers(CustomersAddDTO customersAddDTO)
        {
            try
            {
                if (customersAddDTO is null)
                    throw new CustomersExceptions("El Cliente no puede ser nulo");

                if (this._shopDb.Customers.Any(customer => customer.companyname == customersAddDTO.companyname))
                    throw new CustomersExceptions("El cliente esta registrado");

                Customers customers = new Customers()
                {
                 
                 companyname = customersAddDTO.companyname,
                 contactname = customersAddDTO.contactname,
                 contacttitle = customersAddDTO.contacttitle,
                 address = customersAddDTO.address,
                 email  = customersAddDTO.email,
                 city = customersAddDTO.city,
                 region = customersAddDTO.region,
                 postalcode = customersAddDTO.postalcode,
                 country = customersAddDTO.country,
                 phone  = customersAddDTO.phone,
                 fax = customersAddDTO.fax,
                 creation_date = customersAddDTO.creation_date,
                 creation_user = customersAddDTO.creation_user,
                 
                 
                   
                };
                this._shopDb.Customers.Add(customers);
                this._shopDb.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error guardando el cliente", ex.ToString());
            }

        }

        public void UpdateCustomers(CustomersUpdateDTO customersUpdateDTO)
        {
            try
            {
                if (customersUpdateDTO is null)
                    throw new CustomersExceptions("El cliente no puede ser nulo");

                Customers customers = this._shopDb.Customers.Find(customersUpdateDTO.custid);

                if (customers is null)
                    throw new CustomersExceptions("El cliente no esta Disponible");

                customers.custid = customersUpdateDTO.custid;
                customers.companyname = customersUpdateDTO.companyname;
                customers.contactname = customersUpdateDTO.contactname;
                customers.contacttitle = customersUpdateDTO.contacttitle;
                customers.address = customersUpdateDTO.address;
                customers.email = customersUpdateDTO.email;
                customers.city = customersUpdateDTO.city;
                customers.region = customersUpdateDTO.region;
                customers.postalcode = customersUpdateDTO.postalcode;
                customers.country = customersUpdateDTO.country;
                customers.phone = customersUpdateDTO.phone;
                customers.fax = customersUpdateDTO.fax;
                customers.modify_date = customersUpdateDTO.modify_date;
                customers.modify_date = customersUpdateDTO.modify_date;


                this._shopDb.Customers.Update(customers);
                this._shopDb.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error actualizando el cliente", ex.ToString());
            }

        }

    }

}