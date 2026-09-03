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
    tamagotchi = Tamagotchi.NextDay(tamagotchi);
    (money, tamagotchi) = GetCommand(money, tamagotchi);
    Console.ReadLine();
}
static void WriteStats(Tamagotchi tamagotchi, int money)
{
    Console.WriteLine($"Hunger: {tamagotchi.hunger} \n Boredom: {tamagotchi.boredom} \n Moeny: {money}");
}
static (int,Tamagotchi) GetCommand(int money, Tamagotchi tamagotchi)
{
    string command = Console.ReadLine();
    if (command == "feed" && money > 1)
    {
        money--;
        tamagotchi = Tamagotchi.feed(tamagotchi);
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
