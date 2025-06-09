// string firstName = "Victor";
// string lastName = "Hugo";

// readonly string firstName = "Victor";
// readonly string lastName = "Hugo";

// public string firstName = "Victor";
// public string lastName = "Hugo";

namespace GreetingNameSpace
{

  public class Greeting
  {

    const string firstName = "Victor";
    const string lastName = "Hugo";
    public void Execute()
    {
      Console.WriteLine($"My first name is {firstName} and my last name is {lastName}.");
    }
  }
  public class GreetingWithParams
  {
    public void Execute(string firstName, string lastName)
    {
      Console.WriteLine($"My first name is {firstName} and my last name is {lastName}.");
    }
  }

  public class GreetingWithLambda
  {
    public void Execute(string firstName, string lastName, Action<string> action)
    {
      Console.WriteLine($"My first name is {firstName} and my last name is {lastName}.");
      action($"Hello {firstName} {lastName}!");
    }
  }
}
