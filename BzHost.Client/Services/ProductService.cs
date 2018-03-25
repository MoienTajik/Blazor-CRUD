using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;

namespace BzHost.Client.Services
{
    public class ProductService
    {
        private const string URL = "/api/products";
        private readonly HttpClient http;

        public ProductService(HttpClient httpClient)
        {
            http = httpClient;
        }

        public async Task<Product[]> GetAll()
        {
            return await http.GetJsonAsync<Product[]>(URL);
        }

        public async Task<Product> Get(string id)
        {
            return await http.GetJsonAsync<Product>($"{URL}/{id}");
        }

        public async Task Create(string name)
        {
            await http.SendJsonAsync(HttpMethod.Post, URL, new Product
            {
                Name = name
            });
        }

        public async Task Edit(Product product)
        {
            await http.SendJsonAsync(HttpMethod.Put, URL, product);
        }

        public async Task Delete(Product product)
        {
            await http.SendJsonAsync(HttpMethod.Delete, URL, product);
        }
    }
}