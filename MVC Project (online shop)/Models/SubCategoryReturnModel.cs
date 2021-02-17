using System;

namespace MVC_Project__online_shop_.Models
{
    public class SubCategoryReturnModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string IconPath { get; set; }

        public int CategoryId { get; set; }
    }
}
