using System;

namespace WebApplication1.Models
{
    public class SubCategoryReturnModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IconPath { get; set; }
        public Guid CategoryId { get; set; }
    }
}
