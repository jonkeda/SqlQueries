using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SqlQueries.Test.Contexts
{
    public class Orders
    {
        [Key, Column("OrderID")]
        public int OrderId { get; set; }

        [Column("CustomerID")]
        public string CustomerId { get; set; }

        public string OrderDate { get; set; }
    }
}