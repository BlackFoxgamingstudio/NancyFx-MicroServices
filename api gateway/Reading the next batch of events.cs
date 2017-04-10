
 private async Task<HttpResponseMessage> ReadEvents()
    {
      using (var httpClient = new HttpClient())
      {
        httpClient.BaseAddress = new Uri($"http://{this.loyaltyProgramHost}");
        var response = await httpClient.GetAsync($"/events/?start={this.start}&end={this.start + this.chunkSize}");
        PrettyPrintResponse(response);
        return response;
      }
    }
