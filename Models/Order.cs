using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _3labBackEnd.Models
{
    [Table("CurrentOrders")]
    public class Order
    {
        [Key] public Guid Id { get; set; } = Guid.NewGuid();
        public string OrderName { get; set; }
        public string OrderDescription { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
