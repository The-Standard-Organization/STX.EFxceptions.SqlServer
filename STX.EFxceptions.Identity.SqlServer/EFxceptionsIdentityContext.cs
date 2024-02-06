// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using STX.EFxceptions.Identity.Core;
using STX.EFxceptions.Interfaces.Brokers.DbErrorBroker;
using STX.EFxceptions.Interfaces.Services.EFxceptions;
using STX.EFxceptions.SqlServer.Base.Brokers.DbErrorBroker;
using STX.EFxceptions.SqlServer.Base.Services.Foundations;

namespace STX.EFxceptions.Identity.SqlServer
{
    public class EFxceptionsIdentityContext<TUser, TRole, TKey>
        : IdentityDbContextBase<TUser, TRole, TKey, IdentityUserClaim<TKey>, IdentityUserRole<TKey>,
            IdentityUserLogin<TKey>, IdentityRoleClaim<TKey>, IdentityUserToken<TKey>, SqlException>
       where TUser : IdentityUser<TKey>
       where TRole : IdentityRole<TKey>
       where TKey : IEquatable<TKey>
    {
        public EFxceptionsIdentityContext(DbContextOptions options) : base(options)
        { }

        protected EFxceptionsIdentityContext() : base()
        { }

        protected override IDbErrorBroker<SqlException> CreateErrorBroker() =>
            new SqlServerErrorBroker();

        protected override IEFxceptionService CreateEFxceptionService(
            IDbErrorBroker<SqlException> errorBroker)
        {
            return new SqlServerEFxceptionService(errorBroker);
        }
    }

    public class EFxceptionsIdentityContext<
        TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
        : IdentityDbContextBase<TUser, TRole, TKey,
            TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken, SqlException>
        where TUser : IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
        where TKey : IEquatable<TKey>
        where TUserClaim : IdentityUserClaim<TKey>
        where TUserRole : IdentityUserRole<TKey>
        where TUserLogin : IdentityUserLogin<TKey>
        where TRoleClaim : IdentityRoleClaim<TKey>
        where TUserToken : IdentityUserToken<TKey>
    {
        public EFxceptionsIdentityContext(DbContextOptions options) : base(options)
        { }

        protected EFxceptionsIdentityContext() : base()
        { }

        protected override IDbErrorBroker<SqlException> CreateErrorBroker() =>
            new SqlServerErrorBroker();

        protected override IEFxceptionService CreateEFxceptionService(
            IDbErrorBroker<SqlException> errorBroker)
        {
            return new SqlServerEFxceptionService(errorBroker);
        }
    }
}
