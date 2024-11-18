using ShopWeb.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace ShopWeb.Data.Entities
{

    public class Products : AuditEntity
    {
      [Key]
     public int productid { get; set; }
     public string productname { get; set; }
     public int categoryid { get; set; }
     public int supplierid { get; set; }
     public decimal unitprice { get; set; }
     public bool discontinued { get; set; }

    }
}
