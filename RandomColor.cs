using System.Drawing;
using Console = Colorful.Console;
public class RandomColor
{

  public void Execute(string[] args)
  {
    Random randomNumber = new Random();
    var hashes = new Hashes();

    Color color = Color.FromArgb(randomNumber.Next(256), randomNumber.Next(256), randomNumber.Next(256));

    string hex = ColorTranslator.ToHtml(color);

    Color colorNameFromHex = ColorTranslator.FromHtml(hex);

    if (args.Length == 0)
    {
      // Keep generating a random color
      Console.WriteLine(hashes.Execute(hex), colorNameFromHex);
      return;
    }
    else
    {
      var hue = args[0];

      if (hue == "ask")
      {
        Console.WriteLine("What is your favorite color? ");
        string favoriteColor = Console.ReadLine();

        if (string.IsNullOrEmpty(favoriteColor))
        {
          Console.WriteLine("You did not provide a color!");
          return;
        }
        hue = favoriteColor;
      }

      Color customColorName = ColorTranslator.FromHtml(hue);

      if (customColorName.IsKnownColor)
      {
        Console.WriteLine(hashes.Execute(hue), customColorName);
        return;
      }
      else
      {
        Console.WriteLine("The color you provided is not a known color.");
        return;
      }
    }
  }
}
