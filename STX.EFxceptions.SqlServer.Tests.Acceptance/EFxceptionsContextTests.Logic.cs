// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// --------------------------------------------------------------------------------

using System;
using STX.EFxceptions.SqlServer.Tests.Acceptance.Models.Clients;

namespace STX.EFxceptions.SqlServer.Tests.Acceptance
{
    public partial class EFxceptionsContextTests
    {
        [Fact]
        public void ShouldSaveChangesSuccessfully()
        {
            // given
            var client = new Client
            {
                Id = Guid.NewGuid()
            };

            // when
            context.Clients.Add(client);
            context.SaveChanges();

            // then
            context.Clients.Remove(client);
            context.SaveChanges();
        }
    }
}