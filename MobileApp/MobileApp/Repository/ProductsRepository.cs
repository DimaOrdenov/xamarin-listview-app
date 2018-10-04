using MobileApp.Core.Helpers;
using MobileApp.Models.Common;
using MobileApp.Models.DTO;
using MobileApp.Models.ServerResponse;
using MobileApp.Repository.Base;
using MobileApp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Repository
{
    public class ProductsRepository : BaseRepository, IProductsRepository
    {
        public ProductsRepository() : base(entity: "product")
        {
        }

        public async Task<Result<ProductDTO>> GetProductById(int id)
        {
            Result<Product> productGetResult = await Get<Product>(id.ToString());

            return new Result<ProductDTO>
            {
                Error = productGetResult?.Error,
                Message = productGetResult?.Message,
                Success = productGetResult?.Success ?? false,
                Value = ProductDTO.CreateFromServerResponse(productGetResult?.Value)
            };
        }

        public async Task<Result<IList<ProductDTO>>> GetProductList(string controller = "", Dictionary<string, string> filters = null)
        {
            Result<ProductList> productGetListResult = await Get<ProductList>("", controller, parameters: filters);

            return new Result<IList<ProductDTO>>
            {
                Error = productGetListResult?.Error,
                Message = productGetListResult?.Message,
                Success = productGetListResult?.Success ?? false,
                Value = productGetListResult?.Value?.Products?.Select(x => ProductDTO.CreateFromServerResponse(x)).ToList()
            };
        }

        public void InjectAuthorizationHeader(string token)
        {
            //_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            //Temporary hard-coded authorization
            try
            {


                _client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", token);

                //_client.DefaultRequestHeaders.TryAddWithoutValidation( = new AuthenticationHeaderValue("Bearer", token);
            }
            catch (Exception e)
            {
                DebugHelper.Log(e);
            }
        }
    }
}
