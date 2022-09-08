using System;
using System.Data;
using DAL.Crowdfunding.Entities;

namespace DAL.Crowdfunding.Handler
{
    public static class Mapper
    {
        
        public static User ToUser(IDataRecord reader)
        {
            return new User
            {
                Id = (Guid)reader[nameof(User.Id)],
                Email = (string)reader[nameof(User.Email)],
                FirstName = (string)reader[nameof(User.FirstName)],
                LastName = (string)reader[nameof(User.LastName)],
                Active = (bool)reader[nameof(User.Active)],
                Password = (string)reader[nameof(User.Password)],
                AdminId = reader[nameof(User.AdminId)] is DBNull ? (Guid?)null : (Guid)reader[nameof(User.AdminId)],
                UserId = reader[nameof(User.UserId)] is DBNull ? (Guid?)null : (Guid)reader[nameof(User.UserId)],
                CompanyId = reader[nameof(User.CompanyId)] is DBNull ? (Guid?)null : (Guid)reader[nameof(User.CompanyId)]
            };
        }
    }
}