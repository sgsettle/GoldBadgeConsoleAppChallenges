using System;
using System.Collections.Generic;
using ChallengeTwo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimRepositoryTests
{
    [TestClass]
    public class ClaimRepositoryTests
    {
        private ClaimRepository _claimRepo;
        private Claim _claim;

        [TestInitialize]
        public void Arrange()
        {
            _claimRepo = new ClaimRepository();
            Claim dateOfIncidentOne = new Claim();
            dateOfIncidentOne.DateOfIncident = new DateTime(2020, 08, 15);
            Claim dateOfClaimOne = new Claim();
            dateOfClaimOne.DateOfClaim = new DateTime(2020, 08, 17);
            _claim = new Claim(1, ClaimType.Car, "Car accident on 465", 400.00m, dateOfIncidentOne.DateOfIncident, dateOfClaimOne.DateOfClaim);

            _claimRepo.CreateNewClaim(_claim);
        }

        [TestMethod]
        public void CreateNewClaim_ShouldReturnCorrect()
        {
            ClaimRepository repo = new ClaimRepository();
            Claim dateOfIncident = new Claim();
            dateOfIncident.DateOfIncident = new DateTime(2020, 08, 15);
            Claim dateOfClaim = new Claim();
            dateOfClaim.DateOfClaim = new DateTime(2020, 08, 17);
            Claim claim = new Claim(4, ClaimType.Theft, "Stolen tv", 1600.00m, dateOfIncident.DateOfIncident, dateOfClaim.DateOfClaim);

            repo.CreateNewClaim(claim);

            Assert.AreEqual(claim.ClaimAmount, 1600.00m);
        }

        [TestMethod]
        public void GetClaims_ShouldReturnCorrectCollection()
        {
            Queue<Claim> directory = _claimRepo.GetClaims();

            bool directoryHasMenu = directory.Contains(_claim);

            Assert.IsTrue(directoryHasMenu);
        }

        [TestMethod]
        public void GetClaimByID_ShouldReturnCorrectClaim()
        {
            Claim correctClaim = _claimRepo.GetClaimByID(1);

            Assert.AreEqual(correctClaim.ClaimType, ClaimType.Car);
        }

        [DataTestMethod]
        [DataRow(1, true)]
        public void UpdateExistingItem_ShouldReturnTrue(int id, bool expectedResult)
        {
            bool updateItem = _claimRepo.UpdateExistingClaim(_claim, id); 

            Assert.AreEqual(expectedResult, updateItem); 
        }
    }
}
