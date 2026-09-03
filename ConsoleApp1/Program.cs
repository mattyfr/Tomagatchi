using System;
using System.Data;
using System.Runtime.InteropServices;
using ConsoleApp1;

Console.WriteLine("pick a name for your Tamagotchi");
Tamagotchi tamagotchi = new Tamagotchi{name = Console.ReadLine(), preferedFood = Random.Shared.Next(0,4)};
int money = 0;
while (tamagotchi.isAlive)
{
    WriteStats(tamagotchi, money);
    tamagotchi = NextDay(tamagotchi);
    (money, tamagotchi) = GetCommand(money, tamagotchi);
    Console.ReadLine();
}
static void WriteStats(Tamagotchi tamagotchi, int money)
{
    Console.WriteLine($"Hunger: {tamagotchi.hunger} \n Boredom: {tamagotchi.boredom} \n Moeny: {money}");
}
static Tamagotchi NextDay(Tamagotchi tamagotchi)
{
    int plusHunger = Random.Shared.Next(0,3);
    int plusBoredom = Random.Shared.Next(0,3);
    tamagotchi.hunger += plusHunger;
    tamagotchi.boredom += plusBoredom;
    if (tamagotchi.hunger > 10 || tamagotchi.boredom > 10)
    {
        tamagotchi.isAlive = false;
    }
    return tamagotchi;
}
static (int,Tamagotchi) GetCommand(int money, Tamagotchi tamagotchi)
{
    string command = Console.ReadLine();
    if (command == "feed" && money > 1)
    {
        money--;
        tamagotchi = feed(tamagotchi);
    }
    else if (command == "feed" && money < 1)
    {
        Console.WriteLine("you cant afford food maby get a job");
    }
    else if (command == "pet")
    {
        tamagotchi.boredom-= 2;
        Console.WriteLine ($"You pet {tamagotchi.name} boredom decreased by 2");
    }
    else if (command == "work")
    {
        money += 4;
    }
    return (money, tamagotchi);
}
static Tamagotchi feed(Tamagotchi tamagotchi)
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
            tamagotchi.hunger -=3;
        }
        else
        {
            tamagotchi.hunger -=2;
        }
    }
    if (Choice == 2)
    {
        Console.WriteLine("You feed your tamagatchi meat");
        if (tamagotchi.preferedFood == Choice)
        {
            tamagotchi.hunger -=3;
        }
        else
        {
            tamagotchi.hunger -=2;
        }
    }
    if (Choice == 3)
    {
        Console.WriteLine("You feed your tamagatchi smoothie");
        if (tamagotchi.preferedFood == Choice)
        {
            tamagotchi.hunger -=3;
        }
        else
        {
            tamagotchi.hunger -=2;
        }
    }
    return tamagotchi;
}