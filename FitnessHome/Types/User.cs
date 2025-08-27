using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessHome.Types
{
    internal class User
    {
        public User()
        {
            var member = new Models.Member
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "",
            };
        }
    }
}
