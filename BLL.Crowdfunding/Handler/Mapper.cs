using B = BLL.Crowdfunding.Entities;
using D = DAL.Crowdfunding.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Crowdfunding.Handler
{
    public static class Mapper
    {

        public static B.User? ToBLL(this D.User? user)
        {
            if (user is null) return null;
            return new B.User()
            {
                Id = user.Id,
                Email = user.Email,
                Active = user.Active,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                IsUser = user.UserId is null ? false : true,
                IsAdmin = user.AdminId is null ? false : true,
                HasCompany = user.CompanyId is null ? false : true
            };
        }

        public static D.User ToDAL (this B.User user)
        {
            return new D.User()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Active = user.Active,
                Password = user.Password,
                UserId = user.IsUser ? user.Id : (Guid?)null,
                AdminId = user.IsAdmin ? user.Id : (Guid?)null,
                CompanyId = user.HasCompany ? user.Id : (Guid?)null
            };
        }

    }
}
