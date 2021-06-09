using System;

namespace MvcProjectApi.Models
{
    public class CategoryReturnModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IconPath { get; set; }
    }
}
