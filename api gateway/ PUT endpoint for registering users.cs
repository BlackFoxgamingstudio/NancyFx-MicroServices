 public class UsersModule : NancyModule
  {

 public UsersModule() : base("/users")
    {
      Get("/", _ => registeredUsers.Values);

      Get("/{userId:int}", parameters =>
      {
        int userId = parameters.userId;
        if (registeredUsers.ContainsKey(userId))
          return registeredUsers[userId];
        else
          return HttpStatusCode.NotFound;
      });
…
}
