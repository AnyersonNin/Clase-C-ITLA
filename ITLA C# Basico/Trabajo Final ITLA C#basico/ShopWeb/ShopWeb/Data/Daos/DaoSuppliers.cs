
using ShopWeb.Data.Context;
using ShopWeb.Data.DTO.CategoriesDTO;
using ShopWeb.Data.DTO.SuppliersDTO;
using ShopWeb.Data.Entities;
using ShopWeb.Data.Exceptions;
using ShopWeb.Data.Interfaces;


namespace ShopWeb.Data.Daos
{
    public class DaoSuppliers : ISuppliers
    {
        private readonly ShopDbContext _shopDb;
        private readonly ILogger<DaoSuppliers> logger;

        public DaoSuppliers(ShopDbContext shopDbContext, ILogger<DaoSuppliers> logger)
        {
            this._shopDb = shopDbContext;
            this.logger = logger;
        }

        public SuppliersAddDTO GetSuppliersById(int suppliersid)
        {
            SuppliersAddDTO suppliersReult = new SuppliersAddDTO();
            try
            {
                var suppliers = this._shopDb.Suppliers.Find(suppliersid);
                if (suppliers is null)
                    throw new SupplierExecptions("El Cliente no es valido");

                suppliersReult.supplierid = suppliers.supplierid;
                suppliersReult.companyname = suppliers.companyname;
                suppliersReult.contactname = suppliers.contactname;
                suppliersReult.contacttitle = suppliers.contacttitle;
                suppliersReult.address = suppliers.address;
                suppliersReult.city = suppliers.city;
                suppliersReult.region = suppliers.region;
                suppliersReult.postalcode = suppliers.postalcode;
                suppliersReult.country = suppliers.country;
                suppliersReult.phone = suppliers.phone;
                suppliersReult.fax = suppliers.fax;
                suppliersReult.creation_date = suppliers.creation_date;
                suppliersReult.creation_user = suppliers.creation_user;

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error obteniendo el Cliente", ex.ToString());
            }
            return suppliersReult;
        }

        public List<SuppliersAddDTO> GetSuppliers()
        {

            List<SuppliersAddDTO> suppliers = new List<SuppliersAddDTO>();

            try
            {
                suppliers = (from supplier in this._shopDb.Suppliers
                             where supplier.deleted == false
                             select new SuppliersAddDTO()
                             {
                                 supplierid = supplier.supplierid,
                                 companyname = supplier.companyname,
                                 contactname = supplier.contactname,
                                 contacttitle = supplier.contacttitle,
                                 address = supplier.address,
                                 city = supplier.city,
                                 region = supplier.region,
                                 postalcode = supplier.postalcode,
                                 country = supplier.country,
                                 phone = supplier.phone,
                                 fax = supplier.fax,
                                 creation_date = supplier.creation_date,
                                 creation_user = supplier.creation_user,

                             }).ToList();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error obteniendo el cliente", ex.ToString());
            }

            return suppliers;
        }

        public void RemoveSuppliers(SuppliersRemoveDTO suppliersRemoveDTO)
        {
            try
            {
                var supplier = this._shopDb.Suppliers.Find(suppliersRemoveDTO.Supplierid);

                if (suppliersRemoveDTO is null)
                    throw new SupplierExecptions("El cliente no puede ser nulo");
                if (supplier is null)
                    throw new SupplierExecptions("El cliente no esta disponible");

                supplier.deleted = true;
                supplier.delete_date = suppliersRemoveDTO?.delete_date;
                supplier.delete_user = suppliersRemoveDTO?.delete_user;

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error Removiendo el cliente", ex.ToString());
            }
        }

        public void SaveSuppliers(SuppliersAddDTO suppliersAddDTO)
        {
            try
            {
                if (suppliersAddDTO is null)
                    throw new SupplierExecptions("El cliente no puede ser nulo");
                if (this._shopDb.Suppliers.Any(supplier => supplier.contactname == suppliersAddDTO.contactname))
                    throw new CategoriesExceptions("la suplidor esta registrada");

                Suppliers suppliers = new Suppliers()
                {
                   
                    companyname = suppliersAddDTO.companyname,
                    contactname = suppliersAddDTO.contactname,
                    contacttitle = suppliersAddDTO.contacttitle,
                    address = suppliersAddDTO.address,
                    city = suppliersAddDTO.city,
                    region = suppliersAddDTO.region,
                    postalcode = suppliersAddDTO.postalcode,
                    country = suppliersAddDTO.country,
                    phone = suppliersAddDTO.phone,
                    fax = suppliersAddDTO.fax,
                    creation_date = suppliersAddDTO.creation_date,
                    creation_user = suppliersAddDTO.creation_user,
                };
                this._shopDb.Suppliers.Add(suppliers);
                this._shopDb.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error guardando el Cliente", ex.ToString());
            }
        }

        public void UpdateSuppliers(SuppliersUpdateDTO suppliersUpdateDTO)
        {
         try
         {
                if (suppliersUpdateDTO is null)
                    throw new SupplierExecptions("El cliente no puede ser nulo");

                Suppliers suppliers = this._shopDb.Suppliers.Find(suppliersUpdateDTO.supplierid);

                if (suppliers is null)
                    throw new SupplierExecptions("El cliente no esta disponible");

                suppliers.supplierid = suppliersUpdateDTO.supplierid;
                suppliers.companyname = suppliersUpdateDTO.companyname;
                suppliers.contactname = suppliersUpdateDTO.contactname;
                suppliers.contacttitle = suppliersUpdateDTO.contacttitle;
                suppliers.address = suppliersUpdateDTO.address;
                suppliers.city = suppliersUpdateDTO.city;
                suppliers.region = suppliersUpdateDTO.region;
                suppliers.postalcode = suppliersUpdateDTO.postalcode;
                suppliers.country = suppliersUpdateDTO.country;
                suppliers.phone = suppliersUpdateDTO.phone;
                suppliers.fax = suppliersUpdateDTO.fax;
                suppliers.modify_date = suppliersUpdateDTO.modify_date;
                suppliers.modify_user = suppliersUpdateDTO.modify_user;



         }
         catch (Exception ex)
         {
                this.logger.LogError("Error actualizando el clientes", ex.ToString());
         }


        }

    }

}

