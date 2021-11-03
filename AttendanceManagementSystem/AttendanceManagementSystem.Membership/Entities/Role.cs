using System;
using Microsoft.AspNetCore.Identity;

namespace AttendanceManagementSystem.Membership.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public Role()
            : base()
        {
        }

        public Role(string roleName)
            : base(roleName)
        {
        }
    }
}