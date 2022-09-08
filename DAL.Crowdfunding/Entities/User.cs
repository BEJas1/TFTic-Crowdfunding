using System;

namespace DAL.Crowdfunding.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public bool Active { get; set; }
        public Guid? UserId { get; set; }
        public Guid? AdminId { get; set; }
        public Guid? CompanyId { get; set; }
    }
}