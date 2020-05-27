namespace AHPS
{
    public static class Utilities
    {
        /**
         * Shows the "any key to cont." thingy then waits
         */
        public static void AnyKey()
        {
            System.Console.WriteLine("Press any key to continue...");
            System.Console.ReadKey();
        }
    
        /**
         * Displays text in play mode that requires user input 
         */
        public static void Display(string text)
        {
            System.Console.WriteLine(text);
            var input = System.Console.ReadLine() ?? "" ;
            if (input.Equals("exit"))
            {
                Game.Playing = false;
            }
        }
    
        /**
         * Prompt user for input, returns their response
         */
        public static string Prompt(string text = "", bool bare = false)
        {
            if (!text.Equals(""))
            {
                if (bare)
                {
                    text = text + " ";
                }
                else
                {
                    text = "(" + text + ")";
                }
            }
    
            System.Console.Write(text + "> ");
            return System.Console.ReadLine();
        }
    
        /**
         * I don't even know what this does, I'll remove the type options unless I need them
         */
        public static void Choice(string text, ChoiceType type, int min = 0, int max = 0)
        {
            System.Console.WriteLine(text);
            switch (type)
            {
                case ChoiceType.Boolean:
                    string response;
                    bool did = false;
                    do
                    {
                        response = Prompt("[y/n]", true);
                        if (response.ToLower().Contains("y"))
                        {
                            did = true;
                        }

                    } while (response.Equals(""));

                    Display(did ? "\nYou did it!" : "\nYou didn't do it.");
                    break;
                case ChoiceType.NumberRange:
                    System.Console.Write("(" + min + "-" + max + ") >");
                    break;
                case ChoiceType.String:
                    System.Console.Write("(string) > ");
                    break;
                default:
                    System.Console.WriteLine("Error: parameter 'type' does not match recognizable 'ChoiceType'");
                    break;
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
            System.Environment.Exit(1);
        }
    }
}