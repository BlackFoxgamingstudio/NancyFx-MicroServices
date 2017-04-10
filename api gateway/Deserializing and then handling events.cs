private void HandleEvents(string content)
    {
      WriteLine("Handling events");
      var events = JsonConvert.DeserializeObject<IEnumerable<Event>>(content);
      WriteLine(events);
      WriteLine(events.Count());
      foreach (var ev in events)
      {
        WriteLine(ev.Content);
        dynamic eventData = ev.Content;
        WriteLine("product name from data: " + (string)eventData.item.productName);
        this.start = Math.Max(this.start, ev.SequenceNumber + 1);
      }
    }
