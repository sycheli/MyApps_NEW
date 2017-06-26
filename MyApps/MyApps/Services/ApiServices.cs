using MyApps.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using MyApps.Helpers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MyApps.Services
{
    public class ApiServices
    {
        public async Task  RegisterUserAsync(string email, string password, string confirmPassword)
        {
            var client = new HttpClient();
            var model = new RegisterBindingModel
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };
            var json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync("http://192.168.1.118:61500/api/Account/Register", content);
            
        }

        public async Task LoginAsync(string userName, string password)
        {
            var client = new HttpClient();
            var KeyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username",userName),
                new KeyValuePair<string, string>("passowrd",password),
                new KeyValuePair<string, string>("grant_type","password")
            };
            var request = new HttpRequestMessage(HttpMethod.Post, "http://192.168.1.118:61500/Token");
            request.Content = new FormUrlEncodedContent(KeyValues);
            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            

        }
    }
}
