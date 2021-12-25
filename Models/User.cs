using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _3labBackEnd.Models
{
    [Table("CurrentUsers")]
    public class User
    {
        [Key] public Guid Id { get; set; } = Guid.NewGuid();
        public string UserName { get; set; }
        public string UserProfession { get; set; }
    }
}
