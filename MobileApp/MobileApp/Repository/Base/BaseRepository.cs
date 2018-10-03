using MobileApp.Core.Helpers;
using MobileApp.Models.Common;
using MobileApp.Repository.DataProvider.Http;
using MobileApp.Repository.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Repository.Base
{
    public class BaseRepository
    {
        protected HttpClient _client = null;

        public BaseRepository(string baseUrl = "default", string entity = null)
        {
            _client = new HttpClient(new ExtendedHttpClientHandler());
            _client.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.UtcNow.ToString("r")); //Disable caching

            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (baseUrl == "default")
            {
                baseUrl = Config.BaseUrl;
            }

            if (baseUrl?.EndsWith("/") == true)
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }

            if (entity?.StartsWith("/") == true)
            {
                entity = entity.Substring(1);
            }

            _client.BaseAddress = new Uri(string.Concat(baseUrl, "/", entity));
        }

        protected async Task<Result<TOutbound>> Put<TInbound, TOutbound>(TInbound data, string id, string controller = "")
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            var result = await _client.PutAsync(controller + "/" + id, content);

            if (result.IsSuccessStatusCode)
            {
                return new Result<TOutbound>
                {
                    Success = true,
                    Value = JsonConvert.DeserializeObject<TOutbound>(await result.Content.ReadAsStringAsync())
                };
            }
            else
            {
                var error = new Result<TOutbound>
                {
                    Error = result.StatusCode.ToString(),
                    Message = result.ReasonPhrase,
                    Success = false
                };

                return error;
            }
        }

        protected async Task<Result<TOutbound>> Post<TInbound, TOutbound>(TInbound data, string controller = "")
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            var result = await _client.PostAsync(controller, content);

            if (result.IsSuccessStatusCode)
            {
                return new Result<TOutbound>
                {
                    Success = true,
                    Value = JsonConvert.DeserializeObject<TOutbound>(await result.Content.ReadAsStringAsync())
                };
            }
            else
            {
                var error = new Result<TOutbound>
                {
                    Error = result.StatusCode.ToString(),
                    Message = result.ReasonPhrase,
                    Success = false
                };

                return error;
            }
        }

        protected async Task<Result<IList<TOutbound>>> GetList<TOutbound>(string controller = "", IDictionary<string, string> parameters = null)
        {
            HttpResponseMessage result = null;

            if (parameters == null)
            {
                result = await _client.GetAsync(controller);
            }
            else
            {
                result = await _client.GetAsync(controller + "/" + parameters.ToQueryString());
            }

            if (result.IsSuccessStatusCode)
            {
                return new Result<IList<TOutbound>>
                {
                    Success = true,
                    Value = JsonConvert.DeserializeObject<IList<TOutbound>>(await result.Content.ReadAsStringAsync())
                };
            }
            else
            {
                var error = new Result<IList<TOutbound>>
                {
                    Error = result.StatusCode.ToString(),
                    Message = result.ReasonPhrase,
                    Success = false
                };

                return error;
            }
        }

        protected async Task<Result<TOutbound>> Get<TOutbound>(string id, string controller = "", IDictionary<string, string> parameters = null)
        {
            HttpResponseMessage result = null;

            if (parameters == null)
            {
                result = await _client.GetAsync(controller + "/" + id);
            }
            else
            {
                result = await _client.GetAsync(controller + "/" + id + parameters.ToQueryString());
            }

            if (result.IsSuccessStatusCode)
            {
                return new Result<TOutbound>
                {
                    Success = true,
                    Value = JsonConvert.DeserializeObject<TOutbound>(await result.Content.ReadAsStringAsync())
                };
            }
            else
            {
                var error = new Result<TOutbound>
                {
                    Error = result.StatusCode.ToString(),
                    Message = result.ReasonPhrase,
                    Success = false
                };

                return error;
            }
        }

        protected async Task<Result<TOutbound>> Delete<TOutbound>(string id, string controller = "", IDictionary<string, string> parameters = null)
        {
            HttpResponseMessage result = null;

            if (parameters == null)
            {
                result = await _client.DeleteAsync(controller + "/" + id.ToString());
            }
            else
            {
                result = await _client.DeleteAsync(controller + "/" + id.ToString() + parameters.ToQueryString());
            }

            if (result.IsSuccessStatusCode)
            {
                return new Result<TOutbound>
                {
                    Success = true //No Content
                };
            }
            else
            {
                var error = new Result<TOutbound>
                {
                    Error = result.StatusCode.ToString(),
                    Message = result.ReasonPhrase,
                    Success = false
                };

                return error;
            }
        }
    }
}
