using System.Text;

namespace PhoneService.LoadTests.Providers
{
    public class HttpProvider
    {
        public async Task<string> PostRequest(string uri, object data, string? accessToken = "")
        {
            string response = string.Empty;

            try
            {
                if (!string.IsNullOrWhiteSpace(uri) && data is not null)
                {
                    var request = System.Text.Json.JsonSerializer.Serialize(data);

                    if (!string.IsNullOrWhiteSpace(request))
                    {
                        using (var client = new HttpClient())
                        {
                            var httpRequest = new HttpRequestMessage()
                            {
                                RequestUri = new Uri(uri),
                                Method = HttpMethod.Post,
                                Content = new StringContent(request, Encoding.UTF8, "application/json"),
                            };

                            if (!string.IsNullOrWhiteSpace(accessToken))
                            {
                                httpRequest.Headers.Add("Authorization", $"{accessToken}");
                            }

                            var dataResponse = await client.SendAsync(httpRequest);

                            if(dataResponse is not null) 
                            {
                                response = await dataResponse.Content.ReadAsStringAsync();
                            }
                        }
                    }
                }
            }
            catch
            {}

            return response;
        }

        public async Task<string> GetRequest(string uri, string? accessToken = "")
        {
            var response = string.Empty;

            try
            {
                if (!string.IsNullOrWhiteSpace(uri))
                {
                    using (var client = new HttpClient())
                    {
                        if (!string.IsNullOrWhiteSpace(accessToken))
                        {
                            client.DefaultRequestHeaders.Add("Authorization", $"{accessToken}");
                        }

                        var httpRequest = new HttpRequestMessage()
                        {
                            RequestUri = new Uri(uri),
                            Method = HttpMethod.Get
                        };

                        var data = await client.SendAsync(httpRequest);

                        if (data is not null)
                        {
                            response = await data.Content.ReadAsStringAsync();
                        }
                    }
                }
            }
            catch
            {
            }

            return response;
        }
    }
}
