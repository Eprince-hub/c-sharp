public class NumberGuessing()
{
  readonly Random randomNumber = new Random();

  public string Render()
  {
    int targetNumber = randomNumber.Next(1, 100);
    MatchGuess(targetNumber);
    return "number";
  }

  private static void MatchGuess(int targetNumber)
  {
    int baseCounter = 20;
    string userInput;
    int counter = baseCounter;

    do
    {
      Console.WriteLine("" + targetNumber);
      Console.WriteLine($"You have only {counter} tries!");
      Console.WriteLine("Guess a number between 1 & 100: ");
      userInput = Console.ReadLine()!;

      if (int.TryParse(userInput, out int input))
      {
        counter--;

        // Could use switch statement
        if (input < 1 || input >= 100)
        {
          Console.WriteLine("Out of range - only number 1 - 100 is allowed!");
        }
        else if (input < targetNumber)
        {
          Console.WriteLine("Entered number is less than the target! ");
        }
        else if (input > targetNumber)
        {
          Console.WriteLine("Entered number is greater than the target! ");
        }
        else
        {
          Console.WriteLine($"Congratulations, you made it in {baseCounter - counter} tries!");
        }

        if (counter <= 0)
        {
          Console.WriteLine("You tapped out - you can start the game again");
        }

      }
      else
      {
        Console.WriteLine("Data type not supported - only numbers are allowed!");
        return;
      }
    } while (
      targetNumber != int.Parse(userInput) && counter > 0
    );
  }
}
