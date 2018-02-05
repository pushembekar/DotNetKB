using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MySQLDBConnection
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }
        public int Customer_id { get; set; }
    }
}
