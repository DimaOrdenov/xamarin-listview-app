using MobileApp.Models;
using MobileApp.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Repository.Interfaces
{
    public interface IProductsRepository
    {
        Task<Result<Product>> GetProductById(int id);

        Task<Result<IList<Product>>> GetProductList(Dictionary<string, string> filters = null);
    }
}
