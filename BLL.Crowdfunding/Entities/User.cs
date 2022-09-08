using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Crowdfunding.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public bool Active { get; set; }
        public bool IsUser { get; set; }
        public bool IsAdmin { get; set; }
        public bool HasCompany { get; set; }
    }
}
