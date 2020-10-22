using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication.DAL.Entities
{
   public class ApplicationUser : IdentityUser
    {
        public byte[] AvatarImage { get; set; }

    }
}
