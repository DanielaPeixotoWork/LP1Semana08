using System;
using System.Collections.Generic;

namespace PlayerManager3
{
    public class Player : IComparable<Player>
    {
        public string Name { get; }
        public int Score { get; }

        public Player(string name, int score)
        {
            Name = name;
            Score = score;
        }

        public int CompareTo(Player other)
        {
            return other.Score.CompareTo(Score);
        }
    }

    public class CompareByName : IComparer<Player>
    {
        private readonly bool ascending;

        public CompareByName(bool ascending)
        {
            this.ascending = ascending;
        }

        public int Compare(Player x, Player y)
        {
            if (ascending)
            {
                return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
            }
            else
            {
                return string.Compare(y.Name, x.Name, StringComparison.Ordinal);
            }
        }
    }

    public class Program
    {
        private List<Player> playerList;

        private static void Main()
        {
            Program prog = new Program();
            prog.Start();
        }

        private Program()
        {
            playerList = new List<Player>() {
                new Player("Best player ever", 100),
                new Player("An even better player", 500)
            };
        }

        private void Start()
        {
            string option;

            do
            {
                ShowMenu();
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        InsertPlayer();
                        break;
                    case "2":
                        ListPlayers(playerList);
                        break;
                    case "3":
                        ListPlayersWithScoreGreaterThan();
                        break;
                    case "4":
                        Console.WriteLine("Bye!");
                        break;
                    case "5":
                        ListPlayersByName(true); // Ascending
                        break;
                    case "6":
                        ListPlayersByName(false); // Descending
                        break;
                    default:
                        Console.Error.WriteLine("\n>>> Unknown option! <<<\n");
                        break;
                }

                Console.Write("\nPress any key to continue...");
                Console.ReadKey(true);
                Console.WriteLine("\n");

            } while (option != "4");
        }

        private void ShowMenu()
        {
            Console.WriteLine("Player Manager");
            Console.WriteLine("1. Insert Player");
            Console.WriteLine("2. List All Players");
            Console.WriteLine("3. List Players with Score Greater Than");
            Console.WriteLine("4. Quit");
            Console.WriteLine("5. List Players by Name (Ascending)");
            Console.WriteLine("6. List Players by Name (Descending)");
            Console.Write("Enter option: ");
        }

        private void InsertPlayer()
        {
            Console.Write("Enter player name: ");
            string name = Console.ReadLine();
            Console.Write("Enter player score: ");
            int score;
            while (!int.TryParse(Console.ReadLine(), out score))
            {
                Console.WriteLine("Invalid score. Please enter a valid integer.");
                Console.Write("Enter player score: ");
            }

            playerList.Add(new Player(name, score));
            Console.WriteLine("Player added successfully.");
        }

        private static void ListPlayers(IEnumerable<Player> playersToList)
        {
            Console.WriteLine("Player List:");
            foreach (var player in playersToList)
            {
                Console.WriteLine($"Name: {player.Name}, Score: {player.Score}");
            }
        }

        private void ListPlayersWithScoreGreaterThan()
        {
            Console.Write("Enter the minimum score: ");
            int minScore;
            while (!int.TryParse(Console.ReadLine(), out minScore))
            {
                Console.WriteLine("Invalid score. Please enter a valid integer.");
                Console.Write("Enter the minimum score: ");
            }

            var filteredPlayers = GetPlayersWithScoreGreaterThan(minScore);
            ListPlayers(filteredPlayers);
        }

        private IEnumerable<Player> GetPlayersWithScoreGreaterThan(int minScore)
        {
            foreach (var player in playerList)
            {
                if (player.Score > minScore)
                {
                    yield return player;
                }
            }
        }

        private void ListPlayersByName(bool ascending)
        {
            var sortedPlayers = new List<Player>(playerList);
            sortedPlayers.Sort(new CompareByName(ascending));
            ListPlayers(sortedPlayers);
        }
    }
}
