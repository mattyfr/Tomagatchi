using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using ConsoleApp1;

Tamagotchi tamagotchi = new Tamagotchi();
Console.WriteLine("What do you want to name you tamagotchi");
tamagotchi._name = Console.ReadLine();
while (tamagotchi.GetAlive())
{
    int Choice;
    Console.WriteLine("1: Feed \n 2: Hi \n 3: Teach \n 4: Print stats");
    int.TryParse(Console.ReadLine(), out Choice);
    Console.Clear();
    if (Choice == 1)
    {
        tamagotchi.Feed();
    }
    else if (Choice == 2)
    {
        tamagotchi.Hi();
    }
    else if (Choice == 3)
    {
        tamagotchi.Teach();
    }
    else if (Choice == 4)
    {
        tamagotchi.PrintSats();
    }
    tamagotchi.Tick();

}
