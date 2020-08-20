using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree
{
    public class BadgeRepository
    {
        private Dictionary<int, List<string>> _badgeDirectory = new Dictionary<int, List<string>>();

        // CREATE
        public void CreateNewBadge(int badgeID, List<string> doors)
        {
            _badgeDirectory.Add(badgeID, doors);
        }

        // Casey helped write this to show how it would work if you wanted to utilize the Badge Class... I got it working without the badge class, so I'm going with that for my MVP

        //public void CreateNewBadge(Badge badge)
        //{
        //    _badgeDirectory.Add(badge.BadgeID, badge.Doors);
        //}
        //public Badge GetBadgeByBadgeID(int id)
        //{
        //    Badge badge = new Badge();
        //  // badge.Doors = _badgeDirectory[id];
        //    badge.BadgeID = id;
        //    return badge;
        //}

        // READ
        public Dictionary<int, List<string>> GetBadges()
        {
            return _badgeDirectory;
        }

        public List<string> GetDoorAccessByBadgeID(int badgeID)
        {
            foreach (KeyValuePair<int, List<string>> item in _badgeDirectory)
            {
                if (item.Key == badgeID)
                {
                    return item.Value;
                }
            }

            return null;
        }

        // UPDATE 
        public bool AddDoorToExistingBadge(int originalBadge, string door)
        {
            List<string> existingAccess;

            if (_badgeDirectory.TryGetValue(originalBadge, out existingAccess))
            {
                if (!existingAccess.Contains(door))
                    existingAccess.Add(door);

                return true;
            }
            return false;
        }

        // DELETE
        public bool DeleteExistingBadge(int badgeID)
        {
            return _badgeDirectory.Remove(badgeID);
        }

        public bool RemoveDoorFromExistingBadge(int originalBadge, string door)
        {
            List<string> existingAccess;

            if (_badgeDirectory.TryGetValue(originalBadge, out existingAccess))
            {
                if (existingAccess.Contains(door))
                    existingAccess.Remove(door);

                return true;
            }
            return false;
        }
    }
}
