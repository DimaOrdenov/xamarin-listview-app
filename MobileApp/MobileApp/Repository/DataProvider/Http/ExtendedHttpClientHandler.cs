using MobileApp.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MobileApp.Repository.DataProvider.Http
{
    public class ExtendedHttpClientHandler : HttpClientHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Guid guid = Guid.NewGuid();
            string requestBody = "null";
            string contentHeader = "";
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                if (request.Content != null)
                {
                    requestBody = await request.Content.ReadAsStringAsync();
                    contentHeader = request.Content.Headers.ToString() ?? "";
                }

                DebugHelper.Log(String.Format("---Request({1})---{0}{7}{0}{2}::{3}{0}HEADERS{0}{4}{5}{0}BODY{0}{6}{0}---end---",
                    Environment.NewLine,
                    guid,
                    request.Method,
                    request.RequestUri.AbsoluteUri,
                    request.Headers,
                    contentHeader,
                    requestBody,
                    DateTime.Now));

                long date = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                response = await base.SendAsync(request, cancellationToken);
                long requestTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - date;
                string responseBody = "null";

                if (response.Content != null)
                {
                    responseBody = await response.Content.ReadAsStringAsync();
                }

                DebugHelper.Log(String.Format("---Response({1})---{0}{7}{0}{2}ms{0}{3}::{4}{0}STATUS:{5}{0}BODY{0}{6}{0}---end---",
                    Environment.NewLine,
                    guid,
                    requestTime,
                    request.Method,
                    request.RequestUri.AbsoluteUri,
                    response.StatusCode,
                    responseBody,
                    DateTime.Now));
            }
            catch (Exception e)
            {
                DebugHelper.Log(e.ToString());
            }

            return response;
        }
    }
}
