using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree
{
    public class BadgeUI
    {
        private bool _isRunning = true;
        private readonly BadgeRepository _badgeRepo = new BadgeRepository();

        public void Start()
        {
            SeedContentList();
            RunMenu();
        }

        private void RunMenu()
        {
            while (_isRunning)
            {
                string userInput = GetMenuSelection();
                OpenMenuItem(userInput);
            }
        }

        private string GetMenuSelection()
        {
            Console.Clear();
            Console.WriteLine(
                "Hello Security Admin. What would you like to do?\n" +
                "Select Menu Item:\n" +
                "1. Add a Badge\n" +
                "2. Edit a Badge\n" +
                "3. List All Badges\n" +
                "4. Exit");

            string userInput = Console.ReadLine();
            return userInput;
        }

        private void OpenMenuItem(string userInput)
        {
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    AddABadge();
                    break;
                case "2":
                    UpdateABadge();
                    break;
                case "3":
                    DisplayAllBadges();
                    break;
                case "4":
                    _isRunning = false;
                    return;
                default:
                    Console.WriteLine("Invalid Input.");
                    return;
            }
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }

        private void DisplayAllBadges()
        {
            Dictionary<int, List<string>> listOfBadges = _badgeRepo.GetBadges();

            foreach (KeyValuePair<int, List<string>> item in listOfBadges)
            {
                var badge = new Badge(item.Key, item.Value);
                DisplayBadge(badge);
            }
        }

        private void DisplayBadge(Badge badge)
        {
            Console.WriteLine($"\n" +
                $"{"Badge #",-30}{"Door Access",-30}\n");

            foreach (var item in badge.Doors)
            {
                Console.WriteLine($"{badge.BadgeID,-30}" + item);
            }
        }

       

        private void AddABadge()
        {
            bool addDoorBool = true;
            List<string> listOfDoors = new List<string>();

            Console.Write("What is the number on the badge: ");
            int badgeID = int.Parse(Console.ReadLine());

            Console.Write("List a door it needs access to: ");
            string doorOne = Console.ReadLine();
            listOfDoors.Add(doorOne);

            while (addDoorBool)
            {
                Console.Write("Any other doors (y/n): ");
                string userInput = Console.ReadLine();
                if (userInput == "y")
                {
                    Console.Write("List a door it needs access to: ");
                    string additionalDoor = Console.ReadLine();
                    listOfDoors.Add(additionalDoor);
                }
                else if (userInput == "n")
                {
                    addDoorBool = false;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }

            _badgeRepo.CreateNewBadge(badgeID, listOfDoors);
        }

        private void UpdateABadge()
        {
            Console.Write("What is the badge to update: ");
            int badgeInput = int.Parse(Console.ReadLine());
            DisplayDoorsByID(badgeInput);

            //List<string> accessedDoors = _badgeRepo.GetDoorAccessByBadgeID(badgeInput);
            Console.WriteLine("What would you like to do?\n" +
                "\t 1. Remove a door\n" +
                "\t 2. Add a door");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Console.Write("Which door would you like to remove: ");
                    string removeDoorInput = Console.ReadLine();
                    _badgeRepo.RemoveDoorFromExistingBadge(badgeInput, removeDoorInput);
                    break;
                case "2":
                    Console.Write("What door would you like to add: ");
                    string addDoorInput = Console.ReadLine();
                    _badgeRepo.AddDoorToExistingBadge(badgeInput, addDoorInput);
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }          
        }

        private void DisplayDoorsByID(int badgeInput)
        {
            Console.WriteLine($"Badge ID: {badgeInput}");

            List<string> accessedDoors = _badgeRepo.GetDoorAccessByBadgeID(badgeInput);

            foreach (var item in accessedDoors)
            {
                Console.WriteLine("Accessed Doors: " + item);
            }
        }

        private void SeedContentList()
        {
            List<string> badgeOneDoors = new List<string> { "A7" };

            _badgeRepo.CreateNewBadge(12345, badgeOneDoors);

            List<string> badgeTwoDoors = new List<string> { "A1", "A4", "B1", "B2" };
            _badgeRepo.CreateNewBadge(22345, badgeTwoDoors);

            List<string> badgeThreeDoors = new List<string> { "A4", "A5" };
            _badgeRepo.CreateNewBadge(32345, badgeThreeDoors);
        }
    }
}
