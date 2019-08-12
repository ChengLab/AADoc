
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Services
{
    public class ProductService : IProductService
    {
        public string GetProductById(int productId)
        {
            return "获取产品";
        }
    }
}
