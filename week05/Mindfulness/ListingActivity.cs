using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _promots;
    
    private Random _random;

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
        )
    {
        _random = new Random();

        _promots = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public string GetRandomPrompt()
    {
        int index = _random.Next(_promots.Count);

        return _promots[index];
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt:");

        Console.WriteLine();

        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        

        Console.WriteLine();

        Console.WriteLine("You may begin in: ");
        ShowCountDown(5);

        int count = 0;

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");

            Console.ReadLine();

            count++;
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {count} items!");

        DisplayEnddingMessage();
    }
}