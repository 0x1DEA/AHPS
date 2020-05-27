namespace AHPS
{
    public static class Menu
    {
        private static string _menuText = System.IO.File.ReadAllText("menu.txt");
        
        public static void Show()
        {
            bool selected = false;

            System.Console.Clear();
            System.Console.WriteLine(_menuText);
    
            while (!selected)
            {
                if (int.TryParse(Utilities.Prompt(), out var selection))
                {
                    switch (selection)
                    {
                        case 1:
                            selected = true;
                            Program.Game = new Game();
                            Program.Game.Start();
                            break;
                        case 2:
                            selected = true;
                            System.Console.WriteLine("You have no choices");
                            Utilities.AnyKey();
                            Show();
                            break;
                        case 3:
                            selected = true;
                            Utilities.Close();
                            break;
                        default:
                            System.Console.WriteLine("You must write a value between 1 and 3!!\n");
                            break;
                    }
                }
                else
                {
                    System.Console.WriteLine("You must write an integer!\n");
                }
            }
        }
    }
}