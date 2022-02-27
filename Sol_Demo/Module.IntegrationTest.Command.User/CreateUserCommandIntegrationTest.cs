using Microsoft.VisualStudio.TestTools.UnitTesting;
using Module.Command.User.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Module.IntegrationTest.Command.User
{
    [TestClass]
    public class CreateUserCommandIntegrationTest
    {
        [TestMethod]
        public async Task CreateUserCommand_Success_TestMethod()
        {
            try
            {
                var createUserRequestDTO = new CreateUserRequestDTO()
                {
                    FirstName = "Kishor",
                    LastName = "Naik",
                    Email = "kishor.naik011.net@hotmail.com",
                    Password = "123"
                };

                using var _httpClient = new HttpClient();
                HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("http://localhost:5136/api/users/create", createUserRequestDTO);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var response = await httpResponseMessage.Content.ReadAsStringAsync();

                    Assert.IsTrue(Convert.ToBoolean(response));
                }
                else
                {
                    Assert.IsTrue(false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}