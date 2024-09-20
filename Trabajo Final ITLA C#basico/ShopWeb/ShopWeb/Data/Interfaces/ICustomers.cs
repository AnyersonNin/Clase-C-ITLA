using ShopWeb.Data.DTO.CustomersDTO;
namespace ShopWeb.Data.Interfaces
{
    public interface ICustomers
    {
        void SaveCustomers(CustomersAddDTO customersAddDTO);
        void UpdateCustomers(CustomersUpdateDTO customersAddDTO);
        void RemoveCustomers(CustomersRemoveDTO customersRemoveDTO);
        List<CustomersAddDTO> GetAllCustomers();
        CustomersAddDTO GetCustomersById(int custid);
    }
}
