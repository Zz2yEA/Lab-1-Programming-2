using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_Programming_2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Variables
            int basic_menu = 0;
            bool extraction = false;
            string dialogue = GetSpeech();
            List<string> Divided = SplitString();
            #endregion

            #region Dictionary
            Dictionary<string, int> FullHouse = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);
            foreach (var Charlie in Divided)
            {
                if (FullHouse.ContainsKey(Charlie))
                {
                    FullHouse[Charlie]++;
                }
                else
                {
                    FullHouse.Add(Charlie, 1);
                }
            }
            #endregion

            #region Menu Chioces
            string[] Foxtrot = new string[]
            { "1: MLK's 'I Have A Dream' Speech",
              "2: List of Words",
              "3: Show the Histogram",
              "4: Search for a Word",
              "5: Remove a Word",
              "6: Exit The Histogram"
            };

            Console.WriteLine("-------MLK's 'I Have A Dream' Histogram-------");

            while (!extraction)
            {
                ReadChoice("\nPick A Number: ", Foxtrot, out basic_menu);
                switch (basic_menu)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine(dialogue);
                        Console.WriteLine("\n|Press Any To Go Back To The Menu|");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 2:
                        Console.Clear();
                        PrintList(Divided);
                        Console.WriteLine("\n|Press Any To Go Back To The Menu|");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 3:
                        Console.Clear();
                        PrintHisto(FullHouse);
                        Console.WriteLine("\n|Press Any To Go Back To The Menu|");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 4:
                        Console.Clear();
                        SearchWords(FullHouse);
                        Console.WriteLine("\n|Press Any To Go Back To The Menu|");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 5:
                        Console.Clear();
                        RemoveWord(FullHouse);
                        Console.WriteLine("\n|Press Any To Go Back To The Menu|");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 6:
                        extraction = true;
                        break;
                }
            }
            Console.ReadKey();
            #endregion
        }
        #region Methods
        public static int ReadInteger(string prompt, int min, int max)
        {
            bool Game_Over = false;
            int Ryan = 0;
            Console.Write(prompt);
            while (!Game_Over)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out Ryan) && Ryan >= min && Ryan <= max)
                {
                    Game_Over = true;
                }
                else
                {
                    Console.Write("Enter in an  actual integer baka: ");
                }
            }
            return Ryan;
        }

        public static void ReadString(string prompt, ref string value)
        {
            bool Game_Over = false;
            Console.Write(prompt);
            while (!Game_Over)
            {
                value = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(value))
                {
                    Game_Over = true;
                }
                else
                {
                    Console.Write("Did you just type nothing... Type in a string: ");
                }
            }
        }

        public static void ReadChoice(string prompt, string[] Bravo, out int Gamma)
        {
            for (int Echo = 0; Echo < Bravo.Length; Echo++)
            {
                Console.WriteLine(Bravo[Echo]);
            }
            Gamma = ReadInteger(prompt, 1, Bravo.Length);
        }

        public static string GetSpeech()
        {
            string text = "I say to you today, my friends, so even though we face the difficulties of today and tomorrow, I still have a dream. It is a dream deeply rooted in the American dream. " +
            "I have a dream that one day this nation will rise up and live out the true meaning of its creed: We hold these truths to be self-evident: that all men are created equal. " +
            "I have a dream that one day on the red hills of Georgia the sons of former slaves and the sons of former slave owners will be able to sit down together at the table of brotherhood. " +
            "I have a dream that one day even the state of Mississippi, a state sweltering with the heat of injustice, sweltering with the heat of oppression, will be transformed into an oasis of freedom and justice. " +
            "I have a dream that my four little children will one day live in a nation where they will not be judged by the color of their skin but by the content of their character. " +
            "I have a dream today. I have a dream that one day, down in Alabama, with its vicious racists, with its governor having his lips dripping with the words of interposition and nullification; one day right there in Alabama, little black boys and black girls will be able to join hands with little white boys and white girls as sisters and brothers. " +
            "I have a dream today. I have a dream that one day every valley shall be exalted, every hill and mountain shall be made low, the rough places will be made plain, and the crooked places will be made straight, and the glory of the Lord shall be revealed, and all flesh shall see it together. " +
            "This is our hope. This is the faith that I go back to the South with. With this faith we will be able to hew out of the mountain of despair a stone of hope. With this faith we will be able to transform the jangling discords of our nation into a beautiful symphony of brotherhood. " +
            "With this faith we will be able to work together, to pray together, to struggle together, to go to jail together, to stand up for freedom together, knowing that we will be free one day. " +
            "This will be the day when all of God's children will be able to sing with a new meaning, My country, 'tis of thee, sweet land of liberty, of thee I sing. Land where my fathers died, land of the pilgrim's pride, from every mountainside, let freedom ring. " +
            "And if America is to be a great nation this must become true. So let freedom ring from the prodigious hilltops of New Hampshire. Let freedom ring from the mighty mountains of New York. Let freedom ring from the heightening Alleghenies of Pennsylvania! " +
            "Let freedom ring from the snowcapped Rockies of Colorado! Let freedom ring from the curvaceous slopes of California! But not only that; let freedom ring from Stone Mountain of Georgia! " +
            "Let freedom ring from Lookout Mountain of Tennessee! Let freedom ring from every hill and molehill of Mississippi. From every mountainside, let freedom ring. " +
            "And when this happens, when we allow freedom to ring, when we let it ring from every village and every hamlet, from every state and every city, we will be able to speed up that day when all of God's children, black men and white men, Jews and Gentiles, Protestants and Catholics, will be able to join hands and sing in the words of the old Negro spiritual, Free at last! free at last! thank God Almighty, we are free at last!";
            return text;
        }

        public static List<string> SplitString()
        {
            string dialogue = GetSpeech();
            string[] scroll = dialogue.Split(new char[] { ',', '!', '.', '?', '&', ':', ';', '\n', '\t', '\r', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> Echo = scroll.ToList();
            return Echo;
        }

        public static void PrintList(List<string> paper)
        {
            for (int Delta = 0; Delta < paper.Count; Delta++)
            {
                Console.WriteLine(paper[Delta]);
            }
        }

        public static void PrintHisto(Dictionary<string, int> Melody)
        {
            foreach (KeyValuePair<string, int> Ethan in Melody)
            {
                Console.Write($"{Ethan.Key}");
                Console.CursorLeft = 15;
                for (int i = 0; i < Ethan.Value; i++)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write(" ");
                    Console.ResetColor();
                }
                Console.WriteLine($"{Ethan.Value}");
            }
        }

        public static void SearchWords(Dictionary<string, int> Melody)
        {
            string dialouge = GetSpeech();
            string Draven = " ";
            ReadString("What are word are you looking for: ", ref Draven);
            if (Melody.ContainsKey(Draven))
            {
                Console.WriteLine($"{Draven}");
                Console.CursorLeft = 15;
                for (int Delta = 0; Delta < Draven.Length; Delta++)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write(" ");
                    Console.ResetColor();
                }
                Console.WriteLine(Melody[Draven]);
            }
            string[] paper = dialouge.Split(new char[] { '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
            for (int Delta = 0; Delta < paper.Length; Delta++)
            {
                string[] School = paper[Delta].Split(new char[] { ',', '.', ';', ':', '!', '\n', '\r', '\t', '?', '&', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int College = 0; College < School.Length; College++)
                {
                    if (String.Compare(Draven, School[College], true) == 0)
                    {
                        Console.WriteLine(paper[Delta]);
                    }

                }
            }
        }

        public static void RemoveWord(Dictionary<string, int> Melody)
        {
            string text = GetSpeech();
            bool isRemoved = false;
            string Cross = " ";
            ReadString("what do you want Removed: ", ref Cross);
            if (isRemoved = Melody.Remove(Cross))
            {
                Melody.Remove(text);
            }
            else
            {
                Console.WriteLine($"{Cross} was not found.");
            }

        }

        #endregion
    }
}
