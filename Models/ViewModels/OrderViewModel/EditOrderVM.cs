using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3labBackEnd.Models.ViewModels.OrderViewModel
{
    public class EditOrderVM
    {
        public Guid Id { get; set; }
        public string OrderName { get; set; }
        public string OrderDescription { get; set; }
    }
}
