using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace NewsAggregator.IdentitySample.Data
{
    public class User : IdentityUser<Guid>
    {
        public string FullName { get; set; }
    }
}
