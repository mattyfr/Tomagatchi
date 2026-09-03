using System;

namespace ConsoleApp1;


public class Tamagotchi
{
    public int hunger = 0;
    public int boredom = 0;
    public List<String> words = new List<string> { };
    public bool isAlive = true;
    public string name = "";
    public int preferedFood;
    public static Tamagotchi NextDay(Tamagotchi tamagotchi)
    {
        tamagotchi.hunger += Random.Shared.Next(0, 3);
        tamagotchi.boredom += Random.Shared.Next(0, 3);
        if (tamagotchi.hunger > 10 || tamagotchi.boredom > 10)
        {
            tamagotchi.isAlive = false;
        }
        return tamagotchi;
    }
    public static Tamagotchi feed(Tamagotchi tamagotchi)
    {
        Console.WriteLine("What do you want to feed your tamagotchi. Write the number");
        Console.WriteLine("1: appel \n 2: meat \n 3: smoothie");
        int Choice;
        while (!int.TryParse(Console.ReadLine(), out Choice))
        {
            Console.WriteLine("try again");
        }
        if (Choice == 1)
        {
            Console.WriteLine("You feed your tamagatchi appel");
            if (tamagotchi.preferedFood == Choice)
            {
                tamagotchi.hunger -= 3;
            }
            else
            {
                tamagotchi.hunger -= 2;
            }
        }
        if (Choice == 2)
        {
            Console.WriteLine("You feed your tamagatchi meat");
            if (tamagotchi.preferedFood == Choice)
            {
                tamagotchi.hunger -= 3;
            }
            else
            {
                tamagotchi.hunger -= 2;
            }
        }
        if (Choice == 3)
        {
            Console.WriteLine("You feed your tamagatchi smoothie");
            if (tamagotchi.preferedFood == Choice)
            {
                tamagotchi.hunger -= 3;
            }
            else
            {
                tamagotchi.hunger -= 2;
            }
        }
        return tamagotchi;
    }
    
}
