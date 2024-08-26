using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;
using NuGet.Common;

namespace FrontEnd.Helpers.Implemetations
{
    public class SecurityHelper : ISecurityHelper
    {
        IServiceRepository ServiceRepository;

        public SecurityHelper(IServiceRepository serviceRepository)
        {
            ServiceRepository = serviceRepository;
        }

        public LoginAPI GetUser(UserViewModel user)
        {
            return new LoginAPI();
        }
        public LoginAPI Login(UserViewModel user)
        {
            try
            {
                TokenAPI token = new TokenAPI();

                HttpResponseMessage responseMessage = ServiceRepository
                                .PostResponse("/api/Auth/login", new { user.UserName, user.Password });

                var content = responseMessage.Content.ReadAsStringAsync().Result;

                if (!responseMessage.IsSuccessStatusCode)
                {
                    throw new Exception("Error en la solicitud: " + responseMessage.StatusCode);
                }

                Console.WriteLine(content); // Imprime el contenido para depuración

                LoginAPI loginAPI = JsonConvert.DeserializeObject<LoginAPI>(content);

                token = loginAPI.Token;

                return loginAPI;
            }
            catch (JsonReaderException ex)
            {
                Console.WriteLine("Error al deserializar JSON: " + ex.Message);
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool Register(UserViewModel user)
        {
            try
            {
                HttpResponseMessage responseMessage = ServiceRepository.PostResponse("/api/Auth/register", new
                {
                    Username = user.UserName,
                    Email = user.Email,
                    Password = user.Password
                });

                return responseMessage.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
