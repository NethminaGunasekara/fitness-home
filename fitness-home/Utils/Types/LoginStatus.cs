using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitness_home.Services.Types
{
    public enum LoginStatus
    {
        Success,
        InvalidEmail,
        InvalidPassword,
        DatabaseError,
    }
}
