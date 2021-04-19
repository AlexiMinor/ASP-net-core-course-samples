using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace NewsAggregator.AuthorizationPolicies
{
    public class MinAgeRequirement : IAuthorizationRequirement
    {
        public int MinAge { get; set; }

        public MinAgeRequirement(int minAge)
        {
            MinAge = minAge;
        }
    }
}
