using QRMenuMobile.Models;
using System.Text.Json;

namespace QRMenuMobile.DataServices
{
    public class RestDataServices : IRestDataServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        public RestDataServices()
        {
            _httpClient = new HttpClient();
            _baseAddress = "http://192.168.1.102:8080";
            _url = $"{_baseAddress}/api/";
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }
        public async Task<QrMenuTree> GetQRMenu(string QRCode)
        {
            QrMenuTree qrMenuTree = new QrMenuTree();

            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                return new QrMenuTree()
                {
                    Message = "Not connected",
                    Success = false
                };
            }

            try
            {
                var httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback += (sender, certificate, chain, errors) => true;

                string url = $"{_url}QR/qrmenu?qrCode={QRCode}";
                HttpResponseMessage httpResponse = await _httpClient.GetAsync(url);

                string content = await httpResponse.Content.ReadAsStringAsync();

                qrMenuTree = JsonSerializer.Deserialize<QrMenuTree>(content, _jsonSerializerOptions);

                return qrMenuTree;
            }
            catch (Exception ex)
            {
                return new QrMenuTree()
                {
                    Message = ex.Message,
                    Success = false
                };
            }
        }
    }
}
