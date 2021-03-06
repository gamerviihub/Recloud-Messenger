using Messanger.Server.DataBase.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Messanger.Client.Services.API
{
    public static class UserApi
    {
        public static async Task<User> GetUserInfo(string login, Models.Config config)
        {
            return await Task.Run(async () =>
            {

                using (var httpClientHandler = new HttpClientHandler())
                {
                    httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

                    using (var client = new HttpClient(httpClientHandler))
                    {

                        User user = new User
                        {
                            Login = login,
                            CreatedAt = DateTime.Now,
                            EditedAt = DateTime.Now
                        };

                        User userObject = user;

                        var uri = new Uri($"{config.Host}/api/user");

                        var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                        var request = await client.PostAsync(uri, content);

                        var data = await request.Content.ReadAsStringAsync();

                        userObject = JsonConvert.DeserializeObject<User>(data);

                        if (request.StatusCode == System.Net.HttpStatusCode.Accepted)
                        {
                            userObject.IsRegistered = true;
                        }
                        else if (request.StatusCode == System.Net.HttpStatusCode.Created)
                        {
                            userObject.IsRegistered = false;
                        }
                        else
                        {
                            // ToDo: Сделать обработчико ошибок в приложении
                        }

                        if (String.IsNullOrEmpty(userObject.Password))
                        {
                            userObject.IsRegisteredEnded = false;
                        }
                        else
                        {
                            userObject.IsRegisteredEnded = true;
                        }

                        return userObject;

                    }

                }


            });
        }

        public static async Task<User> UpdateUser(int userId, User user, Models.Config config)
        {
            return await Task.Run(async () =>
            {
                using (var httpClientHandler = new HttpClientHandler())
                {
                    httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

                    using (var client = new HttpClient(httpClientHandler))
                    {

                        var uri = new Uri($"https://{config.Host}/api/User/{user.Id}");

                        var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                        var request = await client.PutAsync(uri, content);

                        var data = await request.Content.ReadAsStringAsync();

                        if (request.StatusCode == System.Net.HttpStatusCode.NoContent)
                        {
                            user.IsRegisteredEnded = true;
                        }
                        else
                        {
                            user.IsRegisteredEnded = false;
                        }

                        return user;

                    }

                }
                

            });
        }
    }
}
