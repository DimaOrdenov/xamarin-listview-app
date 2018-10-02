using MobileApp.Models;
using MobileApp.Models.Common;
using MobileApp.Repository.Base;
using MobileApp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Repository
{
    public class ProductsRepository : BaseRepository, IProductsRepository
    {
        public ProductsRepository() : base(entity: "products")
        {
        }

        public async Task<Result<Product>> GetProductById(int id)
        {
            return await Get<Product>(id.ToString());
        }

        public async Task<Result<IList<Product>>> GetProductList(Dictionary<string, string> filters = null)
        {
            return await GetList<Product>(parameters: filters);
        }
    }
}
