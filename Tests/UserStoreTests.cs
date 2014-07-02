using AspNet.Identity.Bltoolkit;
using BLToolkit.Data;
using NUnit.Framework;

namespace Tests
{
    public class UserStoreTests
    {
        public UserStoreTests()
        {
            DbManager.AddDataProvider(new PostgreSQLDataProvider());
        }

        [Test]
        public void UserIdentityCreateAndFindTest()
        {
            // Create
            var userStore = new UserStore();
            var user = new IdentityUser("John Snow");
            userStore.CreateAsync(user);

            // Check by id, if it was created
            var userFromDb1 = userStore.FindByIdAsync(user.Id);
            Assert.AreEqual("John Snow", userFromDb1.GetAwaiter().GetResult().UserName);

            var userFromDb2 = userStore.FindByNameAsync(user.UserName);
            Assert.AreEqual("John Snow", userFromDb2.GetAwaiter().GetResult().UserName);
        }

        [Test]
        public void UserIdentityUpdate()
        {
            // Create
            var userStore = new UserStore();
            var user = new IdentityUser("John Snow");
            userStore.CreateAsync(user);

            // Update
            user.UserName = "Ned Stark";
            userStore.UpdateAsync(user);

            // Check, if it was updated
            var userFromDb = userStore.FindByIdAsync(user.Id);
            Assert.AreEqual("Ned Stark", userFromDb.GetAwaiter().GetResult().UserName);
        }

        [Test]
        public void UserIdentityDelete()
        {
            // Create
            var userStore = new UserStore();
            var user = new IdentityUser("John Snow");
            userStore.CreateAsync(user);

            // Delete
            userStore.DeleteAsync(user);

            // Check, if it was deleted
            var userFromDb = userStore.FindByIdAsync(user.Id);
            Assert.IsNull(userFromDb.GetAwaiter().GetResult());
        }
    }
}
