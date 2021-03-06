﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_Project_Client.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public Guid SubCategoryId { get; set; }
        public Guid ManufacturerId { get; set; }
        public string Name { get; set; }
        public string VendorUserName { get; set; }
        public string Tags { get; set; }
    }
}
