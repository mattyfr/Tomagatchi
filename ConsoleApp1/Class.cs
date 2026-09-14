using System;

namespace ConsoleApp1;


public class Tamagotchi
{
    private int _hunger = 0;
    private int _boredom = 0;
    private List<String> _words = new List<string> {};
    private bool _isAlive = true;
    public string _name = "";
    public int _preferedFood;
    public void Tick()
    {
        _hunger++;
        _boredom++;
    }
    public void Feed()
    {
        _hunger--;
    }
    public void Hi()
    {
        Console.WriteLine(_words[Random.Shared.Next(0,_words.Count())]);
        reduceBoredom();
    }
    public void Teach()
    {
        Console.WriteLine("What word do you want to teach you tamagotchi");
        _words.Add(Console.ReadLine());
    }
    public void PrintSats()
    {
        Console.WriteLine(_hunger);
        Console.WriteLine(_boredom);
        if (GetAlive())
        {
            Console.WriteLine("Tamagotchi is alive");
        }
        else
        {
            Console.WriteLine("Tamagotchi is dead");
        }
    }
    public bool GetAlive()
    {
        if (_hunger > 10 && _boredom > 10)
        {
            _isAlive=false;
        }
        return _isAlive;
    }
    private void reduceBoredom()
    {
        _boredom--;
    }  
}