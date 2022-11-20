﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs.Book
{
    public class BookUpdateDTO
    {
        public string? Name { get; set; }
        public string? Author { get; set; }
        public decimal Price { get; set; }
    }
}
