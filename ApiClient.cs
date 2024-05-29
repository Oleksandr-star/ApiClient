using System.Net;
using Newtonsoft.Json;

namespace MyApiClient
{
    public class ApiClient
    {
        private readonly HttpClient _client;

        public ApiClient()
        {
            _client = new HttpClient();
        }

        public async Task<ApiResponse<Definition>> GetWordDefinitionAsync(string word)
        {
            string apiKey = "61k2hlgz4adan3p79dnex90n4a32vafsyaz7qogly48cb9g4k";
            string url = $"https://api.wordnik.com/v4/word.json/{word}/definitions?limit=5&api_key={apiKey}";

            try
            {
                var response = await _client.GetAsync(url);
                var responseData = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var definitions = JsonConvert.DeserializeObject<List<Definition>>(responseData)!;
                    return new ApiResponse<Definition>
                    {
                        Message = "Data retrieved successfully",
                        HttpStatusCode = response.StatusCode,
                        Data = definitions
                    };
                }
                else
                {
                    return new ApiResponse<Definition>
                    {
                        Message = "Failed to retrieve data",
                        HttpStatusCode = response.StatusCode,
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<Definition>
                {
                    Message = ex.Message,
                    HttpStatusCode = HttpStatusCode.InternalServerError,
                    Data = null
                };
            }
        }

        public async Task<ApiResponse<string>> GetDataAsync(string url)
        {
            try
            {
                var response = await _client.GetAsync(url);
                var responseData = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var definitions = JsonConvert.DeserializeObject<List<string>>(responseData)!;
                    return new ApiResponse<string>
                    {
                        Message = "Data retrieved successfully",
                        HttpStatusCode = response.StatusCode,
                        Data = definitions
                    };
                }
                else
                {
                    return new ApiResponse<string>
                    {
                        Message = "Failed to retrieve data",
                        HttpStatusCode = response.StatusCode,
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<string>
                {
                    Message = ex.Message,
                    HttpStatusCode = HttpStatusCode.InternalServerError,
                    Data = null
                };
            }
        }

        public async Task<ApiResponse<string>> PostDataAsync(string url, string postData)
        {
            try
            {
                var content = new StringContent(postData);
                var response = await _client.PostAsync(url, content);
                var responseData = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var definitions = JsonConvert.DeserializeObject<List<string>>(responseData)!;
                    return new ApiResponse<string>
                    {
                        Message = "Data retrieved successfully",
                        HttpStatusCode = response.StatusCode,
                        Data = definitions
                    };
                }
                else
                {
                    return new ApiResponse<string>
                    {
                        Message = "Failed to retrieve data",
                        HttpStatusCode = response.StatusCode,
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<string>
                {
                    Message = ex.Message,
                    HttpStatusCode = HttpStatusCode.InternalServerError,
                    Data = null
                };
            }
        }
    }
}