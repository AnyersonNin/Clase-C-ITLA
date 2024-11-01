using DocumentFormat.OpenXml.Wordprocessing;
using Nest;
using ShopWeb.Data.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ShopWeb.Data.Entities
{
    public class Categories: AuditEntity
    {
        [Key]
        
        public int categoryid { get; set; }
        public string categoryname{ get; set; }  
        public string description{ get; set; }

    }
}
