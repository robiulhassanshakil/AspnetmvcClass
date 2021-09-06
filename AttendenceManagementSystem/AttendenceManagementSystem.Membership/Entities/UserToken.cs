using System;
using Microsoft.AspNetCore.Identity;

namespace AttendenceManagementSystem.Membership.Entities
{
    public class UserToken : IdentityUserToken<Guid>
    {
    }
}