using System;

public class Utilities
{
    public static void Print(string text)
    {
        Console.WriteLine(text);
        Console.ReadKey();
    }

    public static void Display(string text)
    {
        Console.WriteLine(text);
        if (Console.ReadLine().ToLower().Equals("exit"))
        {
            Program.playing = false;
        }
    }

    public static string Prompt(string text = "")
    {
        if (!text.Equals(""))
        {
            text = "(" + text + ")";
        }

        Console.Write(text + " > ");
        return Console.ReadLine();
    }

    public static void Choice(string text, ChoiceType type, int min = 0, int max = 0)
    {
        Console.WriteLine(text);
        switch (type)
        {
            case ChoiceType.Boolean:
                bool input;
                if (bool.TryParse(Prompt("true|false"), out input))
                {
                    if (input)
                    {
                        Print("You did it!\n");
                    }
                    else
                    {
                        Print("You didn't do it.\n");
                    }
                }
                else
                {
                    Console.WriteLine("You must write 'true' or 'false'");
                }

                break;
            case ChoiceType.NumberRange:
                Console.Write("(" + min.ToString() + "-" + max.ToString() + ") >");
                break;
            case ChoiceType.String:
                Console.Write("(string) > ");
                break;
        }
    }

    public enum ChoiceType
    {
        Boolean,
        NumberRange,
        String
    }
    
    public static void Close()
    {
        Environment.Exit(1);
    }
}