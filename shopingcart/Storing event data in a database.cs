  public void Raise(string eventName, object content)
    {
      var seqNumber = Interlocked.Increment(ref currentSequenceNumber);
      database.Add(
        new Event(
          seqNumber,
          DateTimeOffset.UtcNow,
          eventName,
          content));
    }
  }
