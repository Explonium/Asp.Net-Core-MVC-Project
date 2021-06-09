using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Project_Client.Models
{
    public class ApiErrorListModel
    {
        public string Value { get; set; }
        public List<ApiErrorModel> Errors { get; set; } = new List<ApiErrorModel>();
    }
}
