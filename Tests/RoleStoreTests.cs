using AspNet.Identity.Bltoolkit;
using BLToolkit.Data;
using BLToolkit.Data.Linq;
using NUnit.Framework;

namespace Tests
{
    public class RoleStoreTests
    {
        public RoleStoreTests()
        {
            DbManager.AddDataProvider(new PostgreSQLDataProvider());
        }

        [Test]
        public void UserIdentityCreateAndFindTest()
        {
            // Create
            var roleStore = new RoleStore();
            var role = new IdentityRole("Warrior");
            roleStore.CreateAsync(role);

            // Check by id, if it was created
            var userFromDb1 = roleStore.FindByIdAsync(role.Id);
            Assert.AreEqual("Warrior", userFromDb1.GetAwaiter().GetResult().Name);

            var userFromDb2 = roleStore.FindByNameAsync(role.Name);
            Assert.AreEqual("Warrior", userFromDb2.GetAwaiter().GetResult().Name);
        }

        [Test]
        public void UserIdentityUpdate()
        {
            // Create
            var roleStore = new RoleStore();
            var role = new IdentityRole("Warrior");
            roleStore.CreateAsync(role);

            // Update
            role.Name = "Wizard";
            roleStore.UpdateAsync(role);

            // Check, if it was updated
            var userFromDb = roleStore.FindByIdAsync(role.Id);
            Assert.AreEqual("Wizard", userFromDb.GetAwaiter().GetResult().Name);
        }

        [Test]
        public void UserIdentityDelete()
        {
            // Create
            var roleStore = new RoleStore();
            var role = new IdentityRole("Warrior");
            roleStore.CreateAsync(role);

            // Delete
            roleStore.DeleteAsync(role);

            // Check, if it was deleted
            var userFromDb = roleStore.FindByIdAsync(role.Id);
            Assert.IsNull(userFromDb.GetAwaiter().GetResult());
        }

        [Test]
        public void ClearData()
        {
            using (var db = new SaisDb())
            {
                db.Roles.Delete();
            }
        }
    }
}
