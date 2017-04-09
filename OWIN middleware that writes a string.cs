

app.UseOwin(buildFunc =>
{
	BuidFunc(next => env =>
  {
    System.Console.WriteLine("Got request");
    return next(env);
  });
  buildFunc.UseNancy();
  });
