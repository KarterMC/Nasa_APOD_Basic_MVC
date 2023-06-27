using Microsoft.AspNetCore.DataProtection.KeyManagement;
using NasaApodClient.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace NasaApodClient
{
    public class NasaPicApiClient : HttpClient
    {
        private readonly string BasePath;
        private readonly string MEDIA_TYPE;
        private readonly string API_KEY;

        public NasaPicApiClient(string baseAddress, string basePath, string mediaType, string apiKey)
        {
            BaseAddress = new Uri(baseAddress);
            BasePath = basePath;
            MEDIA_TYPE = mediaType;
            API_KEY = apiKey;
        }
        public async Task<PicOfTheDay> Get()
        {
            try
            {
                SetupHeaders();

                var response = await GetAsync(BasePath + $"?api_key={API_KEY}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var returnModel = JsonConvert.DeserializeObject
                        <PicOfTheDay>(result);

                    return returnModel;
                }
                else
                {
                    throw new Exception
                        ($"Failed to retrieve items returned {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        protected virtual void SetupHeaders()
        {
            DefaultRequestHeaders.Clear();

            //Define request data format  
            DefaultRequestHeaders.Accept.Add
                (new MediaTypeWithQualityHeaderValue
                (MEDIA_TYPE));
        }
    }
}
