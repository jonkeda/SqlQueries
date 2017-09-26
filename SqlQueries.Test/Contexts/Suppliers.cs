using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Srt2.SqlQueries.Test.Contexts
{
    public class Suppliers
    {
        [Key, Column("SupplierID")]
        public int SupplierId { get; set; }

        public string SupplierName { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}