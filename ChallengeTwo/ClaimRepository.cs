using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo
{
    public class ClaimRepository
    {
        private Queue<Claim> _claimDirectory = new Queue<Claim>();

        // CREATE
        public void CreateNewClaim(Claim content)
        {
            _claimDirectory.Enqueue(content);
        }

        // READ
        public Queue<Claim> GetClaims()
        {
            return _claimDirectory;
        }

        public Claim GetClaimByID(int claimID)
        {
            foreach (Claim item in _claimDirectory)
            {
                if (item.ClaimID == claimID)
                {
                    return item;
                }
            }

            return null;
        }

        // UPDATE
        public bool UpdateExistingClaim(Claim updatedClaim, int originalClaim)
        {
            Claim content = GetClaimByID(originalClaim);
            if (content != null)
            {
                content.ClaimID = updatedClaim.ClaimID;
                content.ClaimType = updatedClaim.ClaimType;
                content.Description = updatedClaim.Description;
                content.DateOfIncident = updatedClaim.DateOfIncident;
                content.DateOfClaim = updatedClaim.DateOfClaim;
                //int itemIndex = _claimDirectory.ToArray().ToList().IndexOf(content);
                //_claimDirectory.ToArray()[itemIndex] = updatedClaim;
                return true;
            }

            return false;
        }

        // DELETE
        public void DeleteExistingClaim()
        {
            _claimDirectory.Dequeue();
        }

        // Did not create test for this method since I never used it
    }
}
