using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3labBackEnd.Models.ViewModels.OrderViewModel
{
    public class CreateOrderVM
    {
        public Guid Id { get; set; }
        public string OrderName { get; set; }
        public string OrderDescription { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
