using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3labBackEnd.Models.ViewModels.UserViewModel
{
    public class CreateUserVM
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string UserProfession { get; set; }
    }
}
