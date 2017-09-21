using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SqlQueries.Test.Contexts
{
    public class Customers
    {
        [Key, Column("CustomerID")]
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string ContactName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }
    }

    public class Orders
    {
        [Key, Column("OrderID")]
        public int OrderId { get; set; }

        [Column("CustomerID")]
        public string CustomerId { get; set; }

        public string OrderDate { get; set; }
    }
}
