using System;
using System.Collections.Generic;
using ChallengeThree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeThreeTests
{
    [TestClass]
    public class BadgeRepositoryTests
    {
        private BadgeRepository _badgeRepo;
        private Dictionary<int, List<string>> _dictionary;

        [TestInitialize]
        public void Arrange()
        {
            _badgeRepo = new BadgeRepository();
            _dictionary = new Dictionary<int, List<string>>();
            _dictionary.Add(1, new List<string> { "A5", "A7" });
        }

        [TestMethod]
        public void CreateBadgeTest_ShouldReturnCorrect()
        {
            BadgeRepository repo = new BadgeRepository();
            List<string> doorsString = new List<string>{ "A1", "B5", "C15"};
            Dictionary<int, List<string>> badge = new Dictionary<int, List<string>>();
            repo.CreateNewBadge(1, doorsString);
            int countTest = _badgeRepo.GetBadges().Count;
            Assert.AreEqual(1, countTest);
        }

        [TestMethod]
        public void GetBadges_ShouldReturnCorrectCollection()
        {
            Arrange();

            Dictionary<int, List<string>> directory = _badgeRepo.GetBadges();

            bool directoryHasBadges = directory.ContainsKey(1);

            Assert.IsTrue(directoryHasBadges);
        }

        [DataTestMethod]
        [DataRow("D55", true)]
        public void UpdateBadge_ShouldReturnTrue(string door, bool expectedResult)
        {
            bool updateBadge = _badgeRepo.AddDoorToExistingBadge(12345, door);

            Assert.AreEqual(expectedResult, updateBadge);
        }

        [TestMethod]
        public void DeleteDoor_()
        {

        }
    }
}
