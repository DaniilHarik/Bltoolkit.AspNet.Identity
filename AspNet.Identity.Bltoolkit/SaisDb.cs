using BLToolkit.Data;
using BLToolkit.Data.Linq;

namespace AspNet.Identity.Bltoolkit
{
    public class SaisDb : DbManager
    {
        public SaisDb()
            : base("MyConfiguration")
        {
        }

        public Table<IdentityUser> Users { get { return GetTable<IdentityUser>(); } }
        public Table<IdentityRole> Roles { get { return GetTable<IdentityRole>(); } }
    }
}
