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
            int badgeID = 1;
            List<string> doors = new List<string>();
            string doorList = "A5, A7";
            doors.Add(doorList);
            _dictionary = new Dictionary<int, List<string>>(badgeID, doors);
        }
    }
}
