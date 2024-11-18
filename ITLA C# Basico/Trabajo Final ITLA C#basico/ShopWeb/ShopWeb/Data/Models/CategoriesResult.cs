using ShopWeb.Data.Base;

namespace ShopWeb.Data.Models
{
    public class CategoriesResult : AuditEntity
    {
        public int categoryid { get; set; }
        public string categoryname { get; set; }
        public string description { get; set; }
    }
}
