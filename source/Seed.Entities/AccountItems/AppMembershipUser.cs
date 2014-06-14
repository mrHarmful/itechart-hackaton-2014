using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;

namespace Seed.Entities.AccountItems
{
    class AppMembershipUser: MembershipUser
    {
        private readonly string _userName;

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ImageUrl { get; set; }
        
        public override object ProviderUserKey
        {
            get { return Id; }
        }

        public override string UserName
        {
            get { return _userName; }
        }

        public AppMembershipUser(string userName)
        {
            _userName = userName;
        }
    }
}
