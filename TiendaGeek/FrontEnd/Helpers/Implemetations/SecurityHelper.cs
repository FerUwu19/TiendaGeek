using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace FrontEnd.Helpers.Implemetations
{
    public class SecurityHelper : ISecurityHelper
    {
        private readonly IServiceRepository ServiceRepository;
        private readonly IHttpContextAccessor HttpContextAccessor;

        public SecurityHelper(IServiceRepository serviceRepository, IHttpContextAccessor httpContextAccessor)
        {
            ServiceRepository = serviceRepository;
            HttpContextAccessor = httpContextAccessor;
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

        public UserProfile GetUserProfile(string username)
        {
            try
            {
                HttpResponseMessage responseMessage = ServiceRepository.GetResponse($"/api/Auth/{username}");

                var content = responseMessage.Content.ReadAsStringAsync().Result; // Usa .Result en lugar de await

                if (!responseMessage.IsSuccessStatusCode)
                {
                    throw new Exception("Error en la solicitud: " + responseMessage.StatusCode);
                }

                // Deserializa el contenido JSON en un objeto UserModel
                UserProfile userProfile = JsonConvert.DeserializeObject<UserProfile>(content);

                return userProfile;
            }
            catch (JsonReaderException ex)
            {
                Console.WriteLine("Error al deserializar JSON: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la solicitud: " + ex.Message);
                throw;
            }
        }

        public bool Logout()
        {
            try
            {
                HttpResponseMessage responseMessage = ServiceRepository.PostResponse("/api/Auth/logout", null);

                if (!responseMessage.IsSuccessStatusCode)
                {
                    throw new Exception("Error en la solicitud: " + responseMessage.StatusCode);
                }

                // Eliminar el token del almacenamiento del cliente
                var context = HttpContextAccessor.HttpContext;
                if (context != null)
                {
                    context.Session.Remove("token");
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
