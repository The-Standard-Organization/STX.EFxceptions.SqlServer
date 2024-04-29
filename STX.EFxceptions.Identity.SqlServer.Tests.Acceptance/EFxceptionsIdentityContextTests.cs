// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace STX.EFxceptions.Identity.SqlServer.Tests.Acceptance
{
    public partial class EFxceptionsIdentityContextTests
    {
        private readonly DbContextOptions<EFxceptionsIdentityContext<IdentityUser, IdentityRole, string>> options;
        private readonly MyEFxceptionsIdentityContext<IdentityUser, IdentityRole, string> context;

        public EFxceptionsIdentityContextTests()
        {
            options = new DbContextOptionsBuilder<EFxceptionsIdentityContext<IdentityUser, IdentityRole, string>>()
                .UseInMemoryDatabase(databaseName: "InMemoryDataBaseIdentity")
                .Options;

            this.context = new MyEFxceptionsIdentityContext<IdentityUser, IdentityRole, string>(options);
        }
    }
}