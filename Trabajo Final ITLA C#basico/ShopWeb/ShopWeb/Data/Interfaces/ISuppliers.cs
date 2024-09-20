using ShopWeb.Data.DTO.SuppliersDTO;

namespace ShopWeb.Data.Interfaces
{
    public interface ISuppliers
    {
        void SaveSuppliers(SuppliersAddDTO suppliersAddDTO);
        void RemoveSuppliers(SuppliersRemoveDTO suppliersRemoveDTO);
        void UpdateSuppliers(SuppliersUpdateDTO suppliersUpdateDTO);
        List<SuppliersAddDTO> GetSuppliers();

        SuppliersAddDTO GetSuppliersById (int supplierId);
    }
}
