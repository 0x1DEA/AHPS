using System;

namespace AnthonyHawkProfessionalSkateboarder
{
    public static class Utilities
    {
        /**
         * Shows the "any key to cont." thingy then waits
         */
        public static void AnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    
        /**
         * Displays text in play mode that requires user input 
         */
        public static void Display(string text)
        {
            Console.WriteLine(text);
            var input = Console.ReadLine() ?? "" ;
            if (input.Equals("exit"))
            {
                Game.Playing = false;
            }
        }
    
        /**
         * Prompt user for input, returns their response
         */
        public static string Prompt(string text = "")
        {
            if (!text.Equals(""))
            {
                text = "(" + text + ")";
            }
    
            Console.Write(text + " > ");
            return Console.ReadLine();
        }
    
        /**
         * I don't even know what this does, I'll remove the type options unless I need them
         */
        public static void Choice(string text, ChoiceType type, int min = 0, int max = 0)
        {
            Console.WriteLine(text);
            switch (type)
            {
                case ChoiceType.Boolean:
                    if (bool.TryParse(Prompt("true|false"), out var input))
                    {
                        Display(input ? "You did it!\n" : "You didn't do it.\n");
                    }
                    else
                    {
                        Console.WriteLine("You must write 'true' or 'false'");
                    }
    
                    break;
                case ChoiceType.NumberRange:
                    Console.Write("(" + min + "-" + max + ") >");
                    break;
                case ChoiceType.String:
                    Console.Write("(string) > ");
                    break;
                default:
                    throw new ArgumentException("Parameter 'type' cannot be null");
            }
        }
        
        public enum ChoiceType
        {
            Boolean,
            NumberRange,
            String
        }
        
        /**
         * Do I need this even?
         */
        public static void Close()
        {
            Environment.Exit(1);
        }
    }
}