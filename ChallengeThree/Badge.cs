using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree
{
    public class Badge
    {
        public Badge() { }
        public Badge(int badgeID, List<string> doors)
        {
            BadgeID = badgeID;
            Doors = doors;
        }

        public int BadgeID { get; set; }
        public List<string> Doors { get; set; }
    }
}
