using System;

internal class Program
{
    public static bool playing;
    public static string[] events;
    public static string[] choices;
    
    public static void Main(string[] args)
    {
        events = System.IO.File.ReadAllLines("events.txt");
        choices = System.IO.File.ReadAllLines("choices.txt");
        ShowMenu();
    }

    public static void ShowMenu()
    {
        bool selected = false;
        int selection;

        Console.Clear();
        Console.WriteLine("Anthony Hawk Professional Skateboarder v0.1b\n");
        Console.WriteLine("1. Play Game");
        Console.WriteLine("2. Options");
        Console.WriteLine("3. Exit");
        Console.WriteLine("\nInput a number 1-3:");

        while (!selected)
        {
            
            if (int.TryParse(Utilities.Prompt(), out selection))
            {
                switch (selection)
                {
                    case 1:
                        selected = true;
                        StartGame();
                        break;
                    case 2:
                        selected = true;
                        Console.WriteLine("You have no choices");
                        Utilities.Print("Press any key to continue");
                        ShowMenu();
                        break;
                    case 3:
                        selected = true;
                        Utilities.Close();
                        break;
                    default:
                        Console.WriteLine("You must write a value between 1 and 3!!\n");
                        break;
                }
            }
            else
            {
                Console.WriteLine("You must write an integer!\n");
            }
        }
    }

    public static void StartGame()
    {
        playing = true;
        Console.Clear();
        Utilities.Print("Press ENTER to advance text. Type 'exit' to return to the main menu.\n");
        Utilities.Print("You are skateboarding.");

        while (playing)
        {
            RandomEvent();
        }
        
        ShowMenu();
    }

    public static void RandomEvent()
    {
        Random rnd = new Random();
        if (rnd.Next(0, 2) == 1)
        {
            Utilities.Choice(choices[rnd.Next(0, choices.Length)], Utilities.ChoiceType.Boolean);
        }
        else
        {
            Utilities.Display(events[rnd.Next(0, choices.Length)]);
        }
    }
}