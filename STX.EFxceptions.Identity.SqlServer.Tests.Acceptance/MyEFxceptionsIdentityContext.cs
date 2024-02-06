// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using STX.EFxceptions.Identity.SqlServer.Tests.Acceptance.Models.Clients;

namespace STX.EFxceptions.Identity.SqlServer.Tests.Acceptance
{
    public class MyEFxceptionsIdentityContext<TUser, TRole, TKey>
        : EFxceptionsIdentityContext<TUser, TRole, TKey>
        where TUser : IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
        where TKey : IEquatable<TKey>
    {
        public MyEFxceptionsIdentityContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
