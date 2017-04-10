namespace LoyaltyProgram
{
  using System.Collections.Generic;
  using Nancy;
  using Nancy.ModelBinding;

  public class UsersModule : NancyModule
  {
    private static IDictionary<int, LoyaltyProgramUser> registeredUsers =
      new Dictionary<int, LoyaltyProgramUser>();


      Post("/", _ =>
      {
        var newUser = this.Bind<LoyaltyProgramUser>();
        this.AddRegisteredUser(newUser);
        return this.CreatedResponse(newUser);
      });
