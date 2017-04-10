private async Task SubscriptionCycleCallback()
    {
      var response = await ReadEvents();
      if (response.StatusCode == HttpStatusCode.OK)
        HandleEvents(await response.Content.ReadAsStringAsync());
      this.timer.Start();
    }
