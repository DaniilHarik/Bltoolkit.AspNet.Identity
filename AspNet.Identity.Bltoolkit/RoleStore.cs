using System.Linq;
using BLToolkit.Data.Linq;
using BLToolkit.DataAccess;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;

namespace AspNet.Identity.Bltoolkit
{
    public class RoleStore : IRoleStore<IdentityRole>
    {
        // ... <---- Here goes dao instance
        public SaisDb Database { get; private set; }

        public RoleStore()
        {
            Database = new SaisDb();
        }

        public Task CreateAsync(IdentityRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }

            new SqlQuery<IdentityRole>().Insert(Database, role);        // TODO: Move to dao
            return Task.FromResult<object>(null);
        }

        public Task DeleteAsync(IdentityRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }

            Database.Roles.Delete(c => c.Id == role.Id);        // TODO: Move to dao
            return Task.FromResult<Object>(null);
        }

        public Task<IdentityRole> FindByIdAsync(string roleId)
        {
            var result = Database.Roles.FirstOrDefault(c => c.Id == roleId);        // TODO: Move to dao
            return Task.FromResult(result);
        }

        public Task<IdentityRole> FindByNameAsync(string roleName)
        {
            var result = Database.Roles.FirstOrDefault(c => c.Name == roleName);        // TODO: Move to dao
            return Task.FromResult(result);
        }

        public Task UpdateAsync(IdentityRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }

            new SqlQuery<IdentityRole>().Update(Database, role);        // TODO: Move to dao
            return Task.FromResult<Object>(null);
        }

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
