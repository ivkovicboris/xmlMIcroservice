using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace xmlMicroservice.DAL.Entites
{
    public class User : IdentityUser
    {
        public Guid UserId { get; set; }
    }
}
