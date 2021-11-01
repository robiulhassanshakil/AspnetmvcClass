using System;
using Microsoft.AspNetCore.Identity;

namespace AttendanceManagementSystem.Membership.Entities
{
    public class UserToken : IdentityUserToken<Guid>
    {
    }
}