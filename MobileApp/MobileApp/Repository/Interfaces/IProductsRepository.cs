using MobileApp.Models.Common;
using MobileApp.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Repository.Interfaces
{
    public interface IProductsRepository : IAuthRepository
    {
        Task<Result<ProductDTO>> GetProductById(int id);

        Task<Result<IList<ProductDTO>>> GetProductList(string controller = "", Dictionary<string, string> filters = null);
    }
}
