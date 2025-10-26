using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace CocktailyWPF.Extensions;

public class HttpRequests
{
    public static readonly HttpClient client = new HttpClient();

    public async Task<HttpResponseMessage> GetDataAsync(string route)
    {
        string url = $"{ApiConfig.BaseUrl}/{route}";

        string token = SessionStorage.Get<string>("accessToken");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await client.GetAsync(url);
        return response;
    }

    public async Task<HttpResponseMessage> PostDataAsync(string route, Object data)
    {
        string url = $"{ApiConfig.BaseUrl}/{route}";

        var json = JsonSerializer.Serialize(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        string token = SessionStorage.Get<string>("accessToken");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await client.PostAsync(url, content);
        return response;
    }

    public async Task<HttpResponseMessage> PutDataAsync(string route, Object data, int id)
    {
        string url = $"{ApiConfig.BaseUrl}/{route}/{id}";

        var json = JsonSerializer.Serialize(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        string token = SessionStorage.Get<string>("accessToken");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await client.PutAsync(url, content);
        return response;
    }

    public async Task<HttpResponseMessage> DeleteDataAsync(string route, int id)
    {
        string url = $"{ApiConfig.BaseUrl}/{route}/{id}";

        string token = SessionStorage.Get<string>("accessToken");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await client.DeleteAsync(url);
        return response;
    }
}
