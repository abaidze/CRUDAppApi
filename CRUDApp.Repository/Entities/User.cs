﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApp.Repository.Entities
{
    public class User
    {
        public int Id { get; set; } //primary key
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsActive{ get; set; }

        public UserProfile UserProfile { get; set; }
    }
}
