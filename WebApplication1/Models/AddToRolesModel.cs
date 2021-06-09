using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProjectApi.Models
{
    public class AddToRolesModel
    {
        public string UserName { get; set; }
        public ICollection<string> Roles { get; set; }
    }
}
