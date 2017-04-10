 public class EventSubscriber
  {
    private readonly string loyaltyProgramHost;
    private long start = 0, chunkSize = 100;
    private readonly Timer timer;

    public EventSubscriber(string loyaltyProgramHost)
    {
      WriteLine("created");
      this.loyaltyProgramHost = loyaltyProgramHost;
      this.timer = new Timer(10 * 1000);
      this.timer.AutoReset = false;
      this.timer.Elapsed += (_, __) => SubscriptionCycleCallback().Wait();
    }
