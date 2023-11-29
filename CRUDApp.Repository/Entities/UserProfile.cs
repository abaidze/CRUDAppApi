using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApp.Repository.Entities
{
    public class UserProfile
    {
        public int Id { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }

        [StringLength(11)]
        public string PersonalNumber { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }
    }
}
