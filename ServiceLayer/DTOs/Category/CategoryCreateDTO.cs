using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs.Category
{
    public class CategoryCreateDTO
    {
        public string? Name { get; set; }
        public int CategoryId { get; set; }
    }
}
