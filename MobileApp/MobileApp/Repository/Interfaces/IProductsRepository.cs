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

        Task<Result<IList<ProductDTO>>> GetProductList(Dictionary<string, string> filters = null);

        Task<Result<IList<ProductDTO>>> SearchProductList(Dictionary<string, string> filters = null);
    }
}
