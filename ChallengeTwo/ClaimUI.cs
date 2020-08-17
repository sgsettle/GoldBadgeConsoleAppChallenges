using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo
{
    public class ClaimUI
    {
        private bool _isRunning = true;
        private readonly ClaimRepository _claimRepo = new ClaimRepository();

        public void Start()
        {
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
                "Welcome to Komodo Claims Department!\n" +
                "Select Menu Item:\n" +
                "1. See All Claims\n" +
                "2. Take Care of Next Claim\n" +
                "3. Enter a New Claim\n" +
                "4. Modify an Existing Claim\n" +
                "5. Exit");

            string userInput = Console.ReadLine();
            return userInput;
        }

        private void OpenMenuItem(string userInput)
        {
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    DisplayAllClaims();
                    break;
                case "2":
                    //
                    break;
                case "3":
                    CreateNewClaim();
                    break;
                case "4":
                    //
                    break;
                case "5":
                    _isRunning = false;
                    return;
                default:
                    Console.WriteLine("Invalid Input.");
                    return;
            }
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        private void DisplayAllClaims()
        {
            List<Claim> listOfClaims = _claimRepo.GetClaims();

            foreach (Claim item in listOfClaims)
            {
                DisplayClaims(item);
            }
        }

        private void DisplayClaims(Claim claim)
        {
            Console.WriteLine($"Claim ID: {claim.ClaimID}\n" +
                $"Claim Type: {claim.ClaimType}\n" +
                $"Description: {claim.Description}\n" +
                $"Amount: {claim.ClaimAmount}\n" +
                $"Date of Accident: {claim.DateOfIncident}\n" +
                $"Date of Claim: {claim.DateOfClaim}\n" +
                $"Is Valid: {claim.IsValid}");
        }

        private void CreateNewClaim()
        {
            Console.Write("Enter Claim ID: ");
            int claimID = int.Parse(Console.ReadLine());

            ClaimType claimType = GetClaimType();

            Console.Write("Enter Description: ");
            string description = Console.ReadLine();

            Console.Write("Enter Amount: $");
            decimal amount = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Date of Accident: ");

            Console.Write("Enter Date of Claim: ");

            Console.Write("Enter if Claim is Valid: ");

            
        }

        private ClaimType GetClaimType()
        {
            Console.WriteLine("Select a Claim Type: " +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int claimTypeID))
                {
                    return (ClaimType)claimTypeID - 1;
                }

                Console.WriteLine("Invalid selection. Please try again.");
            }
        }

        
    }
}
