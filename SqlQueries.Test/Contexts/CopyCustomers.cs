﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Srt2.SqlQueries.Test.Contexts
{
    public class CopyCustomers
    {
        [Key, Column("CustomerID")]
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string ContactName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public int Price { get; set; }

        public int TotalAmount { get; set; }
    }
}
