public class Program : ServiceBase
  {
    private EventSubscriber subscriber;

    public static void Main(string[] args) => new Program().Main();

    public void Main()
    {
      this.subscriber = new EventSubscriber("localhost:5000");
      //Run(this);
      OnStart(null);
      ReadLine();
    }
