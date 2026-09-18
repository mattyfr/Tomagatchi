using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text.Json;
using ConsoleApp1;

Tamagotchi tamagotchi = new Tamagotchi();
if (File.Exists(@"saves.txt"))
{
    Console.WriteLine("Do you want to load previus save file (Y/N)");
    string wantToLoad = Console.ReadLine();
    if (wantToLoad == "Y")
    {
        load();
    }
    else
    {
        Console.WriteLine("You did not want to load");
        Console.WriteLine("What do you want to name you tamagotchi");
        tamagotchi._name = Console.ReadLine();
    }
}
while (tamagotchi.GetAlive())
{
    int Choice;
    Console.WriteLine("1: Feed \n 2: Hi \n 3: Teach \n 4: Print stats \n 5: Save Tamagotchi");
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
    else if (Choice == 5)
    {
        save();
    }
    tamagotchi.Tick();

}
void save()
{
    string saveInfo = JsonSerializer.Serialize<Tamagotchi>(tamagotchi);
    if (File.Exists(@"saves.txt"))
    {
        
    }
    else
    {
        var savefile = File.Create(@"saves.txt");
        savefile.Close();
    }
    File.WriteAllText(@"saves.txt", saveInfo);
}
void load()
{
    tamagotchi = JsonSerializer.Deserialize<Tamagotchi>(File.ReadAllText(@"saves.txt"));
}