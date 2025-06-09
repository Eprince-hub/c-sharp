class Car
{
  string color = "red";

  static void MainCar(string[] args)
  {
    Car benz = new Car();
    Console.WriteLine($"My car is {benz.color} in color");
  }
}


class People
{
  public string personName;
  public string city;
  public int old;
  public People(string name, int age, string address)
  {
    personName = name;
    old = age;
    city = address;
  }
}
