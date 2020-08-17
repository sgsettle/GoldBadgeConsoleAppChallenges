using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo
{
    public class ClaimRepository
    {
        private List<Claim> _claimDirectory = new List<Claim>();

        // CREATE
        public void CreateNewClaim(Claim content)
        {
            _claimDirectory.Add(content);
        }

        // READ
        public List<Claim> GetClaims()
        {
            return _claimDirectory;
        }

        public Claim GetClaimByID(int claimID)
        {
            foreach (Claim item in _claimDirectory)
            {
                if (item.ClaimID)
                {
                    return item;
                }
            }

            return null;
        }

        // UPDATE

        // DELETE

    }
}
