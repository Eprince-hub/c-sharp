

namespace HelloWorld
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var greeting = new Greeting();
            var greetingWithParams = new GreetingWithParams();
            var greetingWithLambda = new GreetingWithLambda();

            Console.WriteLine("Hello, World from JS world!");


            greeting.Execute();
            greetingWithParams.Execute("Alice", "Hernandez");
            greetingWithParams.Execute("Micheal", "Deo");
            greetingWithLambda.Execute("Mary", "Luke", static (greet) => Console.WriteLine(greet));

        }
    }
}
