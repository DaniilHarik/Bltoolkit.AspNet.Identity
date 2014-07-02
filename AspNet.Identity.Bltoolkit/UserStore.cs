using System.Linq;
using System.Threading.Tasks;
using BLToolkit.Data.Linq;
using BLToolkit.DataAccess;
using Microsoft.AspNet.Identity;
using System;

namespace AspNet.Identity.Bltoolkit
{
    public class UserStore : IUserStore<IdentityUser>
    {
        public SaisDb Database { get; private set; }

        /// <summary>
        /// Opens new PostgreSQL connection.
        /// </summary>
        public UserStore()
        {
            // TODO: initialize DAO here
            Database = new SaisDb();
        }

        /// <summary>
        /// Insert a new IdentityUser in the UserTable
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task CreateAsync(IdentityUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            new SqlQuery<IdentityUser>().Insert(Database, user);    // TODO: put into DAO
            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// Returns an IdentityUser instance based on a userId query 
        /// </summary>
        /// <param name="userId">The user's Id</param>
        /// <returns></returns>
        public Task<IdentityUser> FindByIdAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("Null or empty argument: userId");
            }

            var result = Database.Users.FirstOrDefault(c => c.Id == userId);    // TODO: put into DAO
            return result != null ? Task.FromResult(result) : Task.FromResult<IdentityUser>(null);
        }

        /// <summary>
        /// Returns an IdentityUser instance based on a userName query 
        /// </summary>
        /// <param name="userName">The user's name</param>
        /// <returns></returns>
        public Task<IdentityUser> FindByNameAsync(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("Null or empty argument: userName");
            }

            var result = Database.Users.FirstOrDefault(c => c.UserName == userName);    // TODO: put into DAO
            return result != null ? Task.FromResult(result) : Task.FromResult<IdentityUser>(null);
        }

        /// <summary>
        /// Updates the UsersTable with the IdentityUser instance values
        /// </summary>
        /// <param name="user">IdentityUser to be updated</param>
        /// <returns></returns>
        public Task UpdateAsync(IdentityUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            new SqlQuery<IdentityUser>().Update(Database, user);    // TODO: put into DAO
            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task DeleteAsync(IdentityUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            Database.Users.Delete(c => c.Id == user.Id);    // TODO: put into DAO
            return Task.FromResult<Object>(null);
        }

        /// <summary>
        /// Close database connection
        /// </summary>
        public void Dispose()
        {
            if (Database != null)
            {
                Database.Dispose();
                Database = null;
            }
        }
    }
}
