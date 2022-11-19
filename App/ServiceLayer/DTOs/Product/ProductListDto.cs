﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs.Product
{
    public class ProductListDto
    {
        public string? Name { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
