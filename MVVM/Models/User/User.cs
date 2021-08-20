using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP332.MVVM.Models.User
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Role Role { get; set; }


        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }


        // This is only used when seeding data 
        public User(string username,string password, Role role)
        {
            Username = username;
            Password = password;
            Role = role;
        }
    }
}
