﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
                    TakeCareOfNextClaim();
                    break;
                case "3":
                    CreateNewClaim();
                    break;
                case "4":
                    ModifyAClaim();
                    break;
                case "5":
                    _isRunning = false;
                    return;
                default:
                    Console.WriteLine("Invalid Input.");
                    return;
            }
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }

        private void DisplayAllClaims()
        {
            Queue<Claim> listOfClaims = _claimRepo.GetClaims();

            foreach (Claim item in listOfClaims)
            {
                DisplayClaim(item);
            }
        }

        private void DisplayClaim(Claim claim)
        {
            Console.WriteLine($"\n " +
                $"{ "ClaimID",-30}{ "Claim Type",-30}{ "Description",-30}{ "Claim Amount",-30}{ "Date Of Incident",-30}{ "DateOfClaim",-30}{ "IsValid",-30}\n" +
                $"{claim.ClaimID, -30}" +
                $"{claim.ClaimType, -30}" +
                $"{claim.Description, -30}" +
                $"{claim.ClaimAmount, -30}" +
                $"{claim.DateOfIncident, -30}" +
                $"Date of Claim: {claim.DateOfClaim, -30}" +
                $"Is Valid: {claim.IsValid, -30}");
        }

        private void TakeCareOfNextClaim()
        {
            Queue<Claim> claimQueue = _claimRepo.GetClaims();

            bool nextClaimBool = true;

            while (nextClaimBool)
            {
                if (claimQueue.Count > 0)
                {
                    var next = claimQueue.Peek();
                    DisplayClaim(next);
                }

                Console.WriteLine("Do you want to deal with this claim now (y/n):");
                string userInput = Console.ReadLine();

                if (userInput == "y")
                {
                    claimQueue.Dequeue();
                }
                else if (userInput == "n")
                {
                    nextClaimBool = false;
                }
                else
                {
                    Console.WriteLine("Invalid Input.");
                }
            }
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

            DateTime dateOfIncident = GetDateOfIncident();

            DateTime dateOfClaim = GetDateOfClaim();

            Claim newClaim = new Claim(claimID, claimType, description, amount, dateOfIncident, dateOfClaim);

            Console.Write($"Claim is Valid: {newClaim.IsValid}");
            Console.WriteLine();

            _claimRepo.CreateNewClaim(newClaim);
        }

        private ClaimType GetClaimType()
        {
            Console.WriteLine("Select a Claim Type: \n" +
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

        private DateTime GetDateOfIncident()
        {
            Console.Write("Enter Date of Incident (yyyy/mm/dd): ");
            DateTime dateOfIncident = DateTime.Parse(Console.ReadLine());

            return dateOfIncident;
        }

        private DateTime GetDateOfClaim()
        {
            Console.Write("Enter Date of Claim (yyyy/mm/dd): ");
            DateTime dateOfClaim = DateTime.Parse(Console.ReadLine());

            return dateOfClaim;
        }

        private void ModifyAClaim()
        {
            Console.WriteLine("Enter Claim ID:");
            int idInput = int.Parse(Console.ReadLine());
            
            _claimRepo.GetClaimByID(idInput);

            Console.Write("Enter Claim ID: ");
            int claimID = int.Parse(Console.ReadLine());

            ClaimType claimType = GetClaimType();

            Console.Write("Enter Description: ");
            string description = Console.ReadLine();

            Console.Write("Enter Amount: $");
            decimal amount = decimal.Parse(Console.ReadLine());

            DateTime dateOfIncident = GetDateOfIncident();

            DateTime dateOfClaim = GetDateOfClaim();

            Claim updateClaim = new Claim(claimID, claimType, description, amount, dateOfIncident, dateOfClaim);

            Console.Write($"Claim is Valid: {updateClaim.IsValid}");
            Console.WriteLine();

            _claimRepo.UpdateExistingClaim(updateClaim, idInput);
        }

        private void SeedContentList()
        {
            Claim dateOfIncidentOne = new Claim();
            dateOfIncidentOne.DateOfIncident = new DateTime(2020, 08, 15);
            Claim dateOfClaimOne = new Claim();
            dateOfClaimOne.DateOfClaim = new DateTime(2020, 08, 17);
            Claim claimOne = new Claim(1, ClaimType.Car, "Car accident on 465", 400.00m, dateOfIncidentOne.DateOfIncident, dateOfClaimOne.DateOfClaim);

            Claim dateOfIncidentTwo = new Claim();
            dateOfIncidentTwo.DateOfIncident = new DateTime(2020, 08, 11);
            Claim dateOfClaimTwo = new Claim();
            dateOfClaimTwo.DateOfClaim = new DateTime(2020, 08, 12);
            Claim claimTwo = new Claim(2, ClaimType.Home, "House fire in kitchen", 4000.00m, dateOfIncidentTwo.DateOfIncident, dateOfClaimTwo.DateOfClaim);

            Claim dateOfIncidentThree = new Claim();
            dateOfIncidentThree.DateOfIncident = new DateTime(2018, 04, 27);
            Claim dateOfClaimThree = new Claim();
            dateOfClaimThree.DateOfClaim = new DateTime(2018, 06, 01);
            Claim claimThree = new Claim(3, ClaimType.Theft, "Stolen pancakes", 4.00m, dateOfIncidentThree.DateOfIncident, dateOfClaimThree.DateOfClaim);

            _claimRepo.CreateNewClaim(claimOne);
            _claimRepo.CreateNewClaim(claimTwo);
            _claimRepo.CreateNewClaim(claimThree);
        }
    }
}
