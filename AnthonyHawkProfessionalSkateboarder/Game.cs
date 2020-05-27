using System;

namespace AnthonyHawkProfessionalSkateboarder
{
    public class Game
    {
        public static bool Playing;
        private static string[] _events;
        private static string[] _choices;

        public Game()
        {
            _events = System.IO.File.ReadAllLines("events.txt");
            _choices = System.IO.File.ReadAllLines("choices.txt");
        }

        public void Start()
        {
            Playing = true;
            Console.Clear();
            Utilities.Display("Press ENTER to advance text. Type 'exit' to return to the main menu.\n");
            Utilities.Display("You are skateboarding.");

            while (Playing)
            {
                RandomEvent();
            }

            Menu.Show();
        }

        private void RandomEvent()
        {
            Random rnd = new Random();
            if (rnd.Next(0, 2) == 1)
            {
                Utilities.Choice(_choices[rnd.Next(0, _choices.Length)], Utilities.ChoiceType.Boolean);
            }
            else
            {
                Utilities.Display(_events[rnd.Next(0, _choices.Length)]);
            }
        }
    }
}