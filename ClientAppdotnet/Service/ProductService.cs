using System.Net.Http.Json;
using static ClientAppdotnet.Pages.FetchProducts;

namespace ClientAppdotnet.Service
{
    public class ProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public async Task<Product[]> GetProductsAsync()
        {
            return await _http.GetFromJsonAsync<Product[]>("api/productlist")
                   ?? Array.Empty<Product>();
        }
    }

}
