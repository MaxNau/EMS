﻿using System.Collections.Generic;

namespace PowerCoWebSite.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual List<Role> Roles { get; set; }

        public User()
        {
            Roles = new List<Role>();
        }
    }
}