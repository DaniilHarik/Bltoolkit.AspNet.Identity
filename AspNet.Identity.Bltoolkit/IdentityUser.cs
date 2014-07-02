using Microsoft.AspNet.Identity;
using System;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace AspNet.Identity.Bltoolkit
{
    /// <summary>
    /// Class that implements the ASP.NET Identity
    /// IUser interface 
    /// </summary>
    [TableName("users")]
    public class IdentityUser : IUser
    {
        /// <summary>
        /// Default constructor 
        /// </summary>
        public IdentityUser()
        {
            Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Constructor that takes user name as argument
        /// </summary>
        /// <param name="userName"></param>
        public IdentityUser(string userName)
            : this()
        {
            UserName = userName;
        }

        /// <summary>
        /// User ID
        /// </summary>
        [MapField("id"), PrimaryKey]
        public string Id { get; set; }

        /// <summary>
        /// User's name
        /// </summary>
        [MapField("username")]
        public string UserName { get; set; }

        /// <summary>
        /// User's password hash
        /// </summary>
        [MapField("passwordhash")]
        public string PasswordHash { get; set; }

        /// <summary>
        /// User's security stamp
        /// </summary>
        [MapField("securitystamp")]
        public string SecurityStamp { get; set; }
    }
}
