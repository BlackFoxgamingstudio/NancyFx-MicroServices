        private async Task<HttpResponseMessage> DoUpdateUser(LoyaltyProgramUser user)
        {
            using(var httpClient = new HttpClient())
            { 
              httpClient.BaseAddress = new Uri($"http://{this.hostName}");
              var response = await httpClient.PutAsync($"/users/{user.Id}", new  StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));
              ThrowOnTransientFailure(response);
              return response;
            }
        }
    }
