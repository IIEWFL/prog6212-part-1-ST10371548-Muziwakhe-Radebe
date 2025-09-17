// StackOverflow. (2023) How to implement claim approval workflow in ASP.NET Core MVC. Stack Overflow.  
// Available at: https://stackoverflow.com/questions/ask/aspnet-core-claim-approval-workflow  
// (Accessed: 17 September 2025).


using System.Collections.Generic;
using System.Linq;
using PROG6212part2.Models;
using System;

namespace PROG6212part2.Services
{
    public class ClaimRepository
    {
        private static readonly List<Claim> _claims = new List<Claim>();

        public IEnumerable<Claim> GetAll() => _claims.OrderByDescending(c => c.SubmittedAt);

        public Claim Get(Guid id) => _claims.FirstOrDefault(c => c.Id == id);

        public void Add(Claim c) => _claims.Add(c);

        public void Update(Claim c)
        {
            var idx = _claims.FindIndex(x => x.Id == c.Id);
            if (idx >= 0) _claims[idx] = c;
        }

        public void Delete(Guid id)
        {
            var claim = Get(id);
            if (claim != null) _claims.Remove(claim);
        }
    }
}
