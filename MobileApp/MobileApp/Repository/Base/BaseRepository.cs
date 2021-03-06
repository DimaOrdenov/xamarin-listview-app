﻿using MobileApp.Core.Helpers;
using MobileApp.Models.Common;
using MobileApp.Repository.DataProvider.Http;
using MobileApp.Repository.Interfaces;
using Newtonsoft.Json;
using Plugin.DeviceInfo;
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

        private string _controller = "";

        public BaseRepository(string controller = "")
        {
            _client = new HttpClient(new ExtendedHttpClientHandler());
            _client.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.UtcNow.ToString("r")); //Disable caching
            _client.DefaultRequestHeaders.Add("User-Agent",
                String.Format("Xamarin-Mobile-App {0} {1}/{2}", CrossDeviceInfo.Current.Platform.ToString(), CrossDeviceInfo.Current.AppVersion, CrossDeviceInfo.Current.AppBuild));

            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (controller?.StartsWith("/") == true)
            {
                controller = controller.Substring(1);
            }

            _controller = controller;

            _client.BaseAddress = new Uri(Config.BaseUrl);
        }

        protected async Task<Result<TOutbound>> Put<TInbound, TOutbound>(TInbound data, string id, string url = "")
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            string requestUriString = string.Concat(_controller, "/", id);

            if (!string.IsNullOrEmpty(url))
            {
                requestUriString = string.Concat(_controller, "/", url, "/", id);
            }

            var result = await _client.PutAsync(new Uri(requestUriString), content);

            if (result.IsSuccessStatusCode)
            {
                return new Result<TOutbound>
                {
                    Success = true,
                    Value = HttpHelper.DeserializeJsonString<TOutbound>(await result.Content.ReadAsStringAsync())
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

        protected async Task<Result<TOutbound>> Post<TInbound, TOutbound>(TInbound data, string url = "")
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            string requestUriString = string.Concat(_controller);

            if (!string.IsNullOrEmpty(url))
            {
                requestUriString = string.Concat(_controller, "/", url);
            }

            var result = await _client.PostAsync(new Uri(requestUriString), content);

            if (result.IsSuccessStatusCode)
            {
                return new Result<TOutbound>
                {
                    Success = true,
                    Value = HttpHelper.DeserializeJsonString<TOutbound>(await result.Content.ReadAsStringAsync())
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

        protected async Task<Result<IList<TOutbound>>> GetList<TOutbound>(string url = "", IDictionary<string, string> parameters = null)
        {
            HttpResponseMessage result = null;

            string requestUriString = String.Concat(_controller, "/", parameters?.ToQueryString() ?? "");

            if (!string.IsNullOrEmpty(url))
            {
                requestUriString = String.Concat(_controller, "/" , url, "/", parameters?.ToQueryString() ?? "");
            }

            result = await _client.DeleteAsync(new Uri(requestUriString));

            if (result.IsSuccessStatusCode)
            {
                return new Result<IList<TOutbound>>
                {
                    Success = true,
                    Value = HttpHelper.DeserializeJsonString<IList<TOutbound>>(await result.Content.ReadAsStringAsync())
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

        protected async Task<Result<TOutbound>> Get<TOutbound>(string id, string url = "", IDictionary<string, string> parameters = null)
        {
            HttpResponseMessage result = null;

            string requestUriString = _controller;

            if (!string.IsNullOrEmpty(url))
            {
                requestUriString = string.Concat(requestUriString, "/", url);
            }

            if (!string.IsNullOrEmpty(id))
            {
                requestUriString = string.Concat(requestUriString, "/", id);
            }

            if (parameters != null)
            {
                requestUriString = string.Concat(requestUriString, parameters.ToQueryString());
            }

            try
            {
                result = await _client.GetAsync(requestUriString);
            }
            catch (Exception e)
            {
                DebugHelper.Log(e);
            }

            if (result.IsSuccessStatusCode)
            {
                return new Result<TOutbound>
                {
                    Success = true,
                    Value = HttpHelper.DeserializeJsonString<TOutbound>(await result.Content.ReadAsStringAsync())
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

        protected async Task<Result<TOutbound>> Delete<TOutbound>(string id, string url = "", IDictionary<string, string> parameters = null)
        {
            HttpResponseMessage result = null;

            string requestUriString = string.Concat(_controller, "/", id, parameters?.ToQueryString() ?? "");

            if (!string.IsNullOrEmpty(url))
            {
                requestUriString = string.Concat(_controller, "/", url, "/", id, parameters?.ToQueryString() ?? "");
            }

            result = await _client.DeleteAsync(new Uri(requestUriString));

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
