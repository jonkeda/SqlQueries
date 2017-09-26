using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Srt2.SqlQueries.Test.Contexts
{
    public class Orders
    {
        [Key, Column("OrderID")]
        public int OrderId { get; set; }

        [Column("CustomerID")]
        public string CustomerId { get; set; }

        public string OrderDate { get; set; }

        public int Price { get; set; }

        public int TotalAmount { get; set; }


    }
}