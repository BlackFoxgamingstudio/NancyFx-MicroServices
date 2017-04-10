using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Polly;

namespace ApiGatewayMock
{
    public class LoyaltyProgramClient
    {
…    
 private async Task<HttpResponseMessage> DoRegisterUser(LoyaltyProgramUser newUser)
        {
            using(var httpClient = new HttpClient())
            { 
              httpClient.BaseAddress = new Uri($"http://{this.hostName}");
              var response = await httpClient.PostAsync("/users/", new  StringContent(JsonConvert.SerializeObject(newUser), Encoding.UTF8, "application/json"));
              ThrowOnTransientFailure(response);
              return response;
            }
        }
