

namespace HelloWorld
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var greeting = new Greeting();
            var greetingWithParams = new GreetingWithParams();
            var greetingWithLambda = new GreetingWithLambda();
            var randomColor = new RandomColor();
            NumberGuessing numberGuessing = new(); // Works as well

            Console.WriteLine("Hello, World from JS world!");


            greeting.Execute();
            greetingWithParams.Execute("Alice", "Hernandez");
            greetingWithParams.Execute("Micheal", "Deo");
            greetingWithLambda.Execute("Mary", "Luke", static (greet) => Console.WriteLine(greet));
            randomColor.Execute(args);
            numberGuessing.Render();
        }
    }
}


// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World coming from JS!");

// string firstFriend = "Alice";
// string secondFriend = "Bob";

// Console.WriteLine($"My first friend is {firstFriend} and my second friend is {secondFriend}");

// string triangle = """
//     *
//    ***
//   *****
//  *******

// """;

// Console.WriteLine(triangle);
// private static void Program2()
// {
//     for (int i = 0; i < 10; i++)
//     {
//         Console.WriteLine("Program 2!");
//     }
// }
